using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.FitnessClassServices;

public sealed class FitnessClassService(DataContext.DataContext context) : IFitnessClassService
{
    public async Task<Result<PagedResponse<IEnumerable<FitnessClassReadInfo>>>> GetFitnessClassesAsync(FitnessClassFilter filter)
    {
        IQueryable<FitnessClass> fitnessClasses = context.FitnessClasses;

        if (filter.FitnessName is not null)
            fitnessClasses = fitnessClasses.Where(fc => fc.FitnessName.ToLower().Contains(filter.FitnessName.ToLower()));

        if (filter.MaxPrice > 0)
            fitnessClasses = fitnessClasses.Where(fc => fc.Price <= filter.MaxPrice);
        
        if (filter.MinPrice > 0)
            fitnessClasses = fitnessClasses.Where(fc => fc.Price >= filter.MinPrice);

        int totalRecords = await fitnessClasses.CountAsync();

        IQueryable<FitnessClassReadInfo> result = fitnessClasses
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.ToReadInfo());

        PagedResponse<IEnumerable<FitnessClassReadInfo>> response = PagedResponse<IEnumerable<FitnessClassReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<FitnessClassReadInfo>>>.Success(response);
    }

    public async Task<Result<FitnessClassReadInfo>> GetFitnessClassByIdAsync(int classId)
    {
        FitnessClass? fitnessClass = await context.FitnessClasses.FirstOrDefaultAsync(fc => fc.Id == classId);

        return fitnessClass is null
            ? Result<FitnessClassReadInfo>.Failure(Error.NotFound())
            : Result<FitnessClassReadInfo>.Success(fitnessClass.ToReadInfo());
    }

    public async Task<BaseResult> CreateFitnessClassAsync(FitnessClassCreateInfo createInfo)
    {
        await context.FitnessClasses.AddAsync(createInfo.ToFitnessClass());
        int res = await context.SaveChangesAsync();

        return res == 0
            ? BaseResult.Failure(Error.InternalServerError("Data wasn't saved!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateFitnessClassAsync(int id, FitnessClassUpdateInfo updateInfo)
    {
        FitnessClass? existingClass = await context.FitnessClasses.AsTracking().FirstOrDefaultAsync(fc => fc.Id == id);
        if (existingClass is null)
            return BaseResult.Failure(Error.NotFound());

        existingClass.ToUpdatedFitnessClass(updateInfo);
        int res = await context.SaveChangesAsync();

        return res == 0
            ? BaseResult.Failure(Error.InternalServerError("Data wasn't updated!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteFitnessClassAsync(int classId)
    {
        FitnessClass? existingClass = await context.FitnessClasses.AsTracking().FirstOrDefaultAsync(fc => fc.Id == classId);
        if (existingClass is null)
            return BaseResult.Failure(Error.NotFound());

        context.FitnessClasses.Remove(existingClass);
        int res = await context.SaveChangesAsync();

        return res == 0
            ? BaseResult.Failure(Error.InternalServerError("Data wasn't deleted!"))
            : BaseResult.Success();
    }
}
