using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.ScheduleServices;

public sealed class ScheduleService(DataContext.DataContext context) : IScheduleService
{
    public async Task<Result<PagedResponse<IEnumerable<ScheduleReadInfo>>>> GetScheduleAsync(ScheduleFilter filter)
    {
        IQueryable<Schedule> schedules = context.Schedules;

        if (filter.StartDateTime is not null)
        {
            schedules = schedules.Where(s => s.StartDateTime >= filter.StartDateTime);
        }

        if (filter.EndDateTime is not null)
        {
            schedules = schedules.Where(s => s.EndDateTime <= filter.EndDateTime);
        }

        int totalRecords = await schedules.CountAsync();

        IQueryable<ScheduleReadInfo> result = schedules
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());

        PagedResponse<IEnumerable<ScheduleReadInfo>> response = PagedResponse<IEnumerable<ScheduleReadInfo>>.Create(
            filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<ScheduleReadInfo>>>.Success(response);
    }

    public async Task<Result<ScheduleReadInfo>> GetScheduleByIdAsync(int scheduleId)
    {
        Schedule? schedule = await context.Schedules.FirstOrDefaultAsync(s => s.Id == scheduleId);

        return schedule is null
            ? Result<ScheduleReadInfo>.Failure(Error.NotFound())
            : Result<ScheduleReadInfo>.Success(schedule.ToReadInfo());
    }

    public async Task<BaseResult> CreateScheduleAsync(ScheduleCreateInfo createInfo)
    {
        bool conflict = await context.Schedules.AnyAsync(s =>
            s.StartDateTime == createInfo.ScheduleBaseInfo.StartTime && s.EndDateTime == createInfo.ScheduleBaseInfo.EndTime);

        if (conflict)
            return BaseResult.Failure(Error.AlreadyExist());

        await context.Schedules.AddAsync(createInfo.ToSchedule());
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data doesn't saved!!!"));
    }

    public async Task<BaseResult> UpdateScheduleAsync(int id, ScheduleUpdateInfo updateInfo)
    {
        Schedule? existingSchedule = await context.Schedules.FirstOrDefaultAsync(s => s.Id == id);
        if (existingSchedule is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.Schedules.AnyAsync(s =>
            s.Id != id && s.StartDateTime == updateInfo.ScheduleBaseInfo.StartTime && s.EndDateTime == updateInfo.ScheduleBaseInfo.EndTime);

        if (conflict)
            return BaseResult.Failure(Error.Conflict());

        existingSchedule.ToUpdatedSchedule(updateInfo);
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data doesn't updated!!!"));
    }

    public async Task<BaseResult> DeleteScheduleAsync(int scheduleId)
    {
        Schedule? existingSchedule = await context.Schedules.FirstOrDefaultAsync(s => s.Id == scheduleId);
        if (existingSchedule is null)
            return BaseResult.Failure(Error.NotFound());

        context.Schedules.Remove(existingSchedule);
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data doesn't deleted!!!"));
    }
}
