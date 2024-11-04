using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers
{
    public static class FeedbackMappingExtensions
    {
        public static FeedbackReadInfo ToReadInfo(this Feedback feedback)
        {
            return new()
            {
                Id = feedback.Id,
                FeedbackBaseInfo = new()
                {
                    UserId = feedback.UserId,
                    TrainerId = feedback.TrainerId,
                    Comment = feedback.Comment,
                    Rating = feedback.Rating,
                }
            };
        }

        public static Feedback ToFeedback(this FeedbackCreateInfo createInfo)
        {
            return new()
            {
                UserId = createInfo.FeedbackBaseInfo.UserId,
                TrainerId = createInfo.FeedbackBaseInfo.TrainerId,
                Comment = createInfo.FeedbackBaseInfo.Comment,
                Rating = createInfo.FeedbackBaseInfo.Rating
            };
        }

        public static Feedback ToUpdatedFeedback(this Feedback feedback, FeedbackUpdateInfo updateInfo)
        {
            feedback.Id = updateInfo.Id;
            feedback.Version++;
            feedback.UpdatedAt = DateTime.UtcNow;
            feedback.UserId = updateInfo.FeedbackBaseInfo.UserId;
            feedback.TrainerId = updateInfo.FeedbackBaseInfo.TrainerId;
            feedback.Comment = updateInfo.FeedbackBaseInfo.Comment;
            feedback.Rating = updateInfo.FeedbackBaseInfo.Rating;
            return feedback;
        }

        public static Feedback ToDeletedRole(this Feedback feedback)
        {
            feedback.IsDeleted = true;
            feedback.DeletedAt = DateTime.UtcNow;
            feedback.UpdatedAt = DateTime.UtcNow;
            feedback.Version++;
            return feedback;
        }
    }
}