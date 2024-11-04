using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.UserFitnessClassServices;

public sealed class UserFitnessClassService(DataContext.DataContext context) : IUserFitnessClassService
{
     public async Task<Result<PagedResponse<IEnumerable<UserFitnessClassReadInfo>>>> GetUserFitnessClassAsync(UserFitnessClassFilter filter)
    {
        IQueryable<UserFitnessClass> userFitnessClasses = context.UserFitnessClasses;

        if (filter.EnrollmentDate is not null)
            userFitnessClasses = userFitnessClasses.Where(u => u.EnrollmentDate >= filter.EnrollmentDate);
        
        int totalRecords = await userFitnessClasses.CountAsync();

        IQueryable<UserFitnessClassReadInfo> result = userFitnessClasses
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());

        PagedResponse<IEnumerable<UserFitnessClassReadInfo>> response = PagedResponse<IEnumerable<UserFitnessClassReadInfo>>
            .Create(filter.PageNumber,filter.PageSize,totalRecords,result);

        return Result<PagedResponse<IEnumerable<UserFitnessClassReadInfo>>>.Success(response);
    }

    public async Task<Result<UserFitnessClassReadInfo>> GetUserFitnessClassByIdAsync(int id)
    {
        UserFitnessClass? userFitnessClass = await context.UserFitnessClasses.FirstOrDefaultAsync(u => u.Id == id);

        return userFitnessClass is null
            ? Result<UserFitnessClassReadInfo>.Failure(Error.NotFound())
            : Result<UserFitnessClassReadInfo>.Success(userFitnessClass.ToReadInfo());
    }

    public async Task<BaseResult> CreateUserFitnessClassAsync(UserFitnessClassCreateInfo createInfo)
    {
        await context.UserFitnessClasses.AddAsync(createInfo.ToUserFitnessClass());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't saved!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateUserFitnessClassAsync(int id, UserFitnessClassUpdateInfo updateInfo)
    {
        UserFitnessClass? existingUserFitnessClass = await context.UserFitnessClasses.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingUserFitnessClass is null)
            return BaseResult.Failure(Error.NotFound());
                
                
        existingUserFitnessClass.ToUpdatedUserFitnessClass(updateInfo);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't updated!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteUserFitnessClassAsync(int id)
    {
        UserFitnessClass? existingUserFitnessClass = await context.UserFitnessClasses.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingUserFitnessClass is null)
            return BaseResult.Failure(Error.NotFound());

        existingUserFitnessClass.ToDeletedUserFitnessClass();

        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't deleted!!!"))
            : BaseResult.Success();
    }
}