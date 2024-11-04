using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.TrainerServices;

public interface ITrainerService
{
    Task<BaseResult> CreateTrainerAsync(TrainerCreateInfo createInfo);
    Task<BaseResult> UpdateTrainerAsync(int id,TrainerUpdateInfo updateInfo);
    Task<BaseResult> DeleteTrainerAsync(int userId);
    Task<Result<PagedResponse<IEnumerable<TrainerReadInfo>>>> GetTrainerAsync(TrainerFilter filter);
    Task<Result<TrainerReadInfo>> GetTrainerByIdAsync(int id);
}