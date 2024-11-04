using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.UserScheduleServices;

public class UserScheduleService(DataContext.DataContext context) : IUserScheduleService
{
    public async Task<Result<PagedResponse<IEnumerable<UserScheduleReadInfo>>>> GetUserScheduleAsync(UserScheduleFilter filter)
    {
        IQueryable<UserSchedule> userSchedules = context.UserSchedules;

        if (filter.EnrolledAt is not null)
            userSchedules = userSchedules.Where(u => u.EnrolledAt >= filter.EnrolledAt);
        
        int totalRecords = await userSchedules.CountAsync();

        IQueryable<UserScheduleReadInfo> result = userSchedules
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());

        PagedResponse<IEnumerable<UserScheduleReadInfo>> response = PagedResponse<IEnumerable<UserScheduleReadInfo>>
            .Create(filter.PageNumber,filter.PageSize,totalRecords,result);

        return Result<PagedResponse<IEnumerable<UserScheduleReadInfo>>>.Success(response);
    }

    public async Task<Result<UserScheduleReadInfo>> GetUserScheduleByIdAsync(int id)
    {
        UserSchedule? userSchedule = await context.UserSchedules.FirstOrDefaultAsync(u => u.Id == id);

        return userSchedule is null
            ? Result<UserScheduleReadInfo>.Failure(Error.NotFound())
            : Result<UserScheduleReadInfo>.Success(userSchedule.ToReadInfo());
    }

    public async Task<BaseResult> CreateUserScheduleAsync(UserScheduleCreateInfo createInfo)
    {
        
        
        await context.UserSchedules.AddAsync(createInfo.ToUserSchedule());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't saved!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateUserScheduleAsync(int id, UserScheduleUpdateInfo updateInfo)
    {
        UserSchedule? existingUserSchedule = await context.UserSchedules.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingUserSchedule is null)
            return BaseResult.Failure(Error.NotFound());

        existingUserSchedule.ToUpdatedUserSchedule(updateInfo);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't updated!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteUserScheduleAsync(int id)
    {
        UserSchedule? existingUserSchedule = await context.UserSchedules.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingUserSchedule is null)
            return BaseResult.Failure(Error.NotFound());

        existingUserSchedule.ToDeletedUserSchedule();

        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't deleted!!!"))
            : BaseResult.Success();
    }
}