using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.UserServices;

public interface IUserService
{

    Task<Result<PagedResponse<IEnumerable<UserReadInfo>>>> GetUserAsync(UserFilter filter);
    Task<Result<UserReadInfo>> GetUserByIdAsync(int userId);
    Task<BaseResult> CreateUserAsync(UserCreateInfo createInfo);
    Task<BaseResult> UpdateUserAsync(int id,UserUpdateInfo updateInfo);
    Task<BaseResult> DeleteUserAsync(int userId);
}