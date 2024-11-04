using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.FeedbackServices;

public interface IFeedbackService
{
    Task<Result<PagedResponse<IEnumerable<FeedbackReadInfo>>>> GetFeedbackAsync(FeedbackFilter filter);
    Task<Result<FeedbackReadInfo>> GetFeedbackByIdAsync(int id);
    Task<BaseResult> CreateFeedbackAsync(FeedbackCreateInfo createInfo);
    Task<BaseResult> UpdateFeedbackAsync(int id,FeedbackUpdateInfo updateInfo);
    Task<BaseResult> DeleteFeedbackAsync(int id);
}