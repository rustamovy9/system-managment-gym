using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.UserScheduleServices;

public interface IUserScheduleService
{
    Task<BaseResult> CreateUserScheduleAsync(UserScheduleCreateInfo info);
    Task<BaseResult> UpdateUserScheduleAsync(int id,UserScheduleUpdateInfo info);
    Task<BaseResult> DeleteUserScheduleAsync(int id);
    Task<Result<PagedResponse<IEnumerable<UserScheduleReadInfo>>>> GetUserScheduleAsync(UserScheduleFilter filter);
    Task<Result<UserScheduleReadInfo>> GetUserScheduleByIdAsync(int id);
}