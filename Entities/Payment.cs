namespace SystemManagmentGym.Entities;

public sealed class Payment : BaseEntity
{
    public int UserId { get; set; }
    public int UserScheduleId { get; set; } 
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public User User { get; set; }
    public UserSchedule UserSchedule { get; set; }
}