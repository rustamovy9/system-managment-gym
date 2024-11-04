namespace SystemManagmentGym.DTOs;

public readonly record struct PaymentBaseInfo(
    int UserId,
    int UserScheduleId,
    decimal Amount,
    DateTime PaymentDate);

public readonly record struct PaymentReadInfo(
    int Id,
    PaymentBaseInfo PaymentBaseInfo);

public readonly record struct PaymentCreateInfo(
    PaymentBaseInfo PaymentBaseInfo);

public readonly record struct PaymentUpdateInfo(
    int Id,
    PaymentBaseInfo PaymentBaseInfo);
