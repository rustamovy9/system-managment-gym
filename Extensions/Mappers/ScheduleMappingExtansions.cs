using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class ScheduleMappingExtensions
{
    public static ScheduleReadInfo ToReadInfo(this Schedule schedule)
    {
        return new(
            schedule.Id,
            new ScheduleBaseInfo(
                schedule.FitnessClassId,
                schedule.TrainerId,
                schedule.StartDateTime,
                schedule.EndDateTime)
        );
    }

    public static Schedule ToSchedule(this ScheduleCreateInfo createInfo)
    {
        return new()
        {
            FitnessClassId = createInfo.ScheduleBaseInfo.FitnessClassId,
            TrainerId = createInfo.ScheduleBaseInfo.TrainerId,
            StartDateTime = createInfo.ScheduleBaseInfo.StartTime,
            EndDateTime = createInfo.ScheduleBaseInfo.EndTime,
        };
    }

    public static Schedule ToUpdatedSchedule(this Schedule schedule, ScheduleUpdateInfo updateInfo)
    {
        schedule.Id = updateInfo.Id;
        schedule.UpdatedAt = DateTime.UtcNow;
        schedule.Version++;
        schedule.FitnessClassId = updateInfo.ScheduleBaseInfo.FitnessClassId;
        schedule.TrainerId = updateInfo.ScheduleBaseInfo.TrainerId;
        schedule.StartDateTime = updateInfo.ScheduleBaseInfo.StartTime;
        schedule.EndDateTime = updateInfo.ScheduleBaseInfo.EndTime;;
        return schedule;
    }

    public static Schedule ToDeletedSchedule(this Schedule schedule)
    {
        schedule.IsDeleted = true;
        schedule.DeletedAt = DateTime.UtcNow;
        schedule.UpdatedAt = DateTime.UtcNow;
        schedule.Version++;
        return schedule;
    }
}