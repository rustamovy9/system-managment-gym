using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.ScheduleServices;

public interface IScheduleService
{
    Task<Result<PagedResponse<IEnumerable<ScheduleReadInfo>>>> GetScheduleAsync(ScheduleFilter filter);
    Task<Result<ScheduleReadInfo>> GetScheduleByIdAsync(int scheduleId);
    Task<BaseResult> CreateScheduleAsync(ScheduleCreateInfo createInfo);
    Task<BaseResult> UpdateScheduleAsync(int id, ScheduleUpdateInfo updateInfo);
    Task<BaseResult> DeleteScheduleAsync(int scheduleId);
}