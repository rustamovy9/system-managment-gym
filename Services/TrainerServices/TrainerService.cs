using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.TrainerServices;

public sealed class TrainerService(DataContext.DataContext context) : ITrainerService
{
    public async Task<Result<PagedResponse<IEnumerable<TrainerReadInfo>>>> GetTrainerAsync(TrainerFilter filter)
    {
        IQueryable<Trainer> trainers = context.Trainers;

        if (filter.FirstName is not null)
            trainers = trainers.Where(t => t.FirstName.ToLower().Contains(filter.FirstName.ToLower()));
        
        if (filter.LastName is not null)
            trainers = trainers.Where(t => t.LastName.ToLower().Contains(filter.LastName.ToLower()));
        
        if (filter.Specialization is not null)
            trainers = trainers.Where(t => t.Specialization.ToLower().Contains(filter.Specialization.ToLower()));
        
        int totalRecords = await trainers.CountAsync();

        IQueryable<TrainerReadInfo> result = trainers
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());
        

        PagedResponse<IEnumerable<TrainerReadInfo>> response = PagedResponse<IEnumerable<TrainerReadInfo>>
            .Create(filter.PageNumber,filter.PageSize,totalRecords,result);

        return Result<PagedResponse<IEnumerable<TrainerReadInfo>>>.Success(response);
    }

    public async Task<Result<TrainerReadInfo>> GetTrainerByIdAsync(int id)
    {
        Trainer? trainer = await context.Trainers.FirstOrDefaultAsync(u => u.Id == id);

        return trainer is null
            ? Result<TrainerReadInfo>.Failure(Error.NotFound())
            : Result<TrainerReadInfo>.Success(trainer.ToReadInfo());
    }

    public async Task<BaseResult> CreateTrainerAsync(TrainerCreateInfo createInfo)
    {
        bool conflict = await context.Trainers.AnyAsync(t => t.Email.ToLower() == createInfo.TrainerBaseInfo.Email.ToLower() || t.PhoneNumber == createInfo.TrainerBaseInfo.PhoneNumber);
        if (conflict)
            return BaseResult.Failure(Error.AlreadyExist());
        
        await context.Trainers.AddAsync(createInfo.ToTrainer());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't saved!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateTrainerAsync(int id, TrainerUpdateInfo updateInfo)
    {
        Trainer? existingTrainer = await context.Trainers.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingTrainer is null)
            return BaseResult.Failure(Error.NotFound());
        
        bool conflict = await context.Trainers.AnyAsync(x
            => x.Id != id && x.Email.ToLower() ==
            updateInfo.TrainerBaseInfo.Email.ToLower() || x.PhoneNumber == updateInfo.TrainerBaseInfo.PhoneNumber);

        if (conflict)
            return BaseResult.Failure(Error.Conflict());

        existingTrainer.ToUpdatedTrainer(updateInfo);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't updated!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteTrainerAsync(int id)
    {
        Trainer? existingTrainer = await context.Trainers.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingTrainer is null)
            return BaseResult.Failure(Error.NotFound());

        existingTrainer.ToDeletedTrainer();

        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't deleted!!!"))
            : BaseResult.Success();
    }
}