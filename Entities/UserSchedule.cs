namespace SystemManagmentGym.Entities;

public sealed class UserSchedule : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    public DateTime EnrolledAt { get; set; }
    public bool IsPaid { get; set; }
    
    public Payment Payment { get; set; }
}