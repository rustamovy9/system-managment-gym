using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.UserFitnessClassServices;

public interface IUserFitnessClassService
{
    Task<Result<PagedResponse<IEnumerable<UserFitnessClassReadInfo>>>> GetUserFitnessClassAsync(UserFitnessClassFilter filter);
    Task<Result<UserFitnessClassReadInfo>> GetUserFitnessClassByIdAsync(int id);
    Task<BaseResult> CreateUserFitnessClassAsync(UserFitnessClassCreateInfo createInfo);
    Task<BaseResult> UpdateUserFitnessClassAsync(int id,UserFitnessClassUpdateInfo updateInfo);
    Task<BaseResult> DeleteUserFitnessClassAsync(int id);
}