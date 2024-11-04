using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.FitnessClassServices;

public interface IFitnessClassService
{
    Task<Result<PagedResponse<IEnumerable<FitnessClassReadInfo>>>> GetFitnessClassesAsync(FitnessClassFilter filter);
    Task<Result<FitnessClassReadInfo>> GetFitnessClassByIdAsync(int classId);
    Task<BaseResult> CreateFitnessClassAsync(FitnessClassCreateInfo createInfo);
    Task<BaseResult> UpdateFitnessClassAsync(int id, FitnessClassUpdateInfo updateInfo);
    Task<BaseResult> DeleteFitnessClassAsync(int classId);
}