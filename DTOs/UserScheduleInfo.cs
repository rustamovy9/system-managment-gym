namespace SystemManagmentGym.DTOs;

public readonly record struct UserScheduleBaseInfo(
    int UserId,
    int ScheduleId,
    DateTime EnrolledAt,
    bool IsPaid);

public readonly record struct UserScheduleReadInfo(
    int Id,
    UserScheduleBaseInfo UserScheduleBaseInfo,
    UserReadInfo UserReadInfo,
    ScheduleReadInfo ScheduleReadInfo,
    PaymentReadInfo PaymentReadInfo);

public readonly record struct UserScheduleCreateInfo(
    UserScheduleBaseInfo UserScheduleBaseInfo);

public readonly record struct UserScheduleUpdateInfo(
    int Id,
    UserScheduleBaseInfo UserScheduleBaseInfo);
