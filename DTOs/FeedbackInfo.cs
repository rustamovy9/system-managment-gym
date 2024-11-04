namespace SystemManagmentGym.DTOs;

public readonly record struct FeedbackBaseInfo(
    int UserId,
    int TrainerId,
    string? Comment,
    int Rating);

public readonly record struct FeedbackReadInfo(
    int Id,
    FeedbackBaseInfo FeedbackBaseInfo);

public readonly record struct FeedbackCreateInfo(
    FeedbackBaseInfo FeedbackBaseInfo);

public readonly record struct FeedbackUpdateInfo(
    int Id,
    FeedbackBaseInfo FeedbackBaseInfo);