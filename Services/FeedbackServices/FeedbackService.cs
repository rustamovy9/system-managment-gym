using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.FeedbackServices;

public sealed class FeedbackService(DataContext.DataContext context) : IFeedbackService
{
    public async Task<Result<PagedResponse<IEnumerable<FeedbackReadInfo>>>> GetFeedbackAsync(FeedbackFilter filter)
    {
        IQueryable<Feedback> feedbacks = context.Feedbacks;

        if (filter.Rating.HasValue)
            feedbacks = feedbacks.Where(f => f.Rating == filter.Rating.Value);
        
        int totalRecords = await feedbacks.CountAsync();

        IQueryable<FeedbackReadInfo> result =  feedbacks
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(f => f.ToReadInfo());

        PagedResponse<IEnumerable<FeedbackReadInfo>> response = PagedResponse<IEnumerable<FeedbackReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<FeedbackReadInfo>>>.Success(response);
    }

    public async Task<Result<FeedbackReadInfo>> GetFeedbackByIdAsync(int feedbackId)
    {
        Feedback? feedback = await context.Feedbacks.FirstOrDefaultAsync(f => f.Id == feedbackId);

        return feedback is null
            ? Result<FeedbackReadInfo>.Failure(Error.NotFound())
            : Result<FeedbackReadInfo>.Success(feedback.ToReadInfo());
    }

    public async Task<BaseResult> CreateFeedbackAsync(FeedbackCreateInfo createInfo)
    {
        await context.Feedbacks.AddAsync(createInfo.ToFeedback());
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Feedback data was not saved."));
    }

    public async Task<BaseResult> UpdateFeedbackAsync(int id, FeedbackUpdateInfo updateInfo)
    {
        Feedback? existingFeedback = await context.Feedbacks.AsTracking().FirstOrDefaultAsync(f => f.Id == id);
        if (existingFeedback is null)
            return BaseResult.Failure(Error.NotFound());

        existingFeedback.ToUpdatedFeedback(updateInfo);
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Feedback data was not updated."));
    }

    public async Task<BaseResult> DeleteFeedbackAsync(int feedbackId)
    {
        Feedback? existingFeedback = await context.Feedbacks.AsTracking().FirstOrDefaultAsync(f => f.Id == feedbackId);
        if (existingFeedback is null)
            return BaseResult.Failure(Error.NotFound());

        context.Feedbacks.Remove(existingFeedback);
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Feedback data was not deleted."));
    }
}
