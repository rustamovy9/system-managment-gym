namespace SystemManagmentGym.DTOs;

public readonly record struct ScheduleBaseInfo(
    int FitnessClassId,
    int TrainerId,
    DateTime StartTime,
    DateTime EndTime);

public readonly record struct ScheduleReadInfo(
    int Id,
    ScheduleBaseInfo ScheduleBaseInfo);

public readonly record struct ScheduleCreateInfo(
    ScheduleBaseInfo ScheduleBaseInfo);

public readonly record struct ScheduleUpdateInfo(
    int Id,
    ScheduleBaseInfo ScheduleBaseInfo);
