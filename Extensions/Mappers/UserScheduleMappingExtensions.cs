using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class UserScheduleMappingExtensions
{
    public static UserScheduleReadInfo ToReadInfo(this UserSchedule userSchedule)
    {
        return new UserScheduleReadInfo()
        {
            Id = userSchedule.Id,
            ScheduleReadInfo = userSchedule.Schedule.ToReadInfo(),
            UserReadInfo = userSchedule.User.ToReadInfo(),
            PaymentReadInfo = userSchedule.Payment.ToReadInfo(),
            UserScheduleBaseInfo = new()
            {
                ScheduleId = userSchedule.ScheduleId,
                UserId = userSchedule.UserId,
                EnrolledAt = userSchedule.EnrolledAt,
                IsPaid = userSchedule.IsPaid,
            }
        };
    }

    public static UserSchedule ToUserSchedule(this UserScheduleCreateInfo createInfo)
    {
        return new()
        {
            ScheduleId = createInfo.UserScheduleBaseInfo.ScheduleId,
            UserId = createInfo.UserScheduleBaseInfo.UserId,
            EnrolledAt = createInfo.UserScheduleBaseInfo.EnrolledAt,
            IsPaid = createInfo.UserScheduleBaseInfo.IsPaid,
        };
    }

    public static UserSchedule ToUpdatedUserSchedule(this UserSchedule userSchedule, UserScheduleUpdateInfo updateInfo)
    {
        userSchedule.ScheduleId = updateInfo.UserScheduleBaseInfo.ScheduleId;
        userSchedule.UserId = updateInfo.UserScheduleBaseInfo.UserId;
        userSchedule.EnrolledAt = updateInfo.UserScheduleBaseInfo.EnrolledAt;
        userSchedule.IsPaid = updateInfo.UserScheduleBaseInfo.IsPaid;
        userSchedule.UpdatedAt = DateTime.UtcNow;
        userSchedule.Version++;
        return userSchedule;
    }

    public static UserSchedule ToDeletedUserSchedule(this UserSchedule userSchedule)
    {
        userSchedule.DeletedAt = DateTime.UtcNow;
        userSchedule.IsDeleted = true;
        userSchedule.UpdatedAt = DateTime.UtcNow;
        userSchedule.Version++;
        return userSchedule;
    }
}