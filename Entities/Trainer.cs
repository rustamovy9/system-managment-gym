namespace SystemManagmentGym.Entities;

public sealed class Trainer : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Specialization { get; set; } = null!;
    public decimal MonthSalary { get; set; }
    public decimal BonusSalary { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; } = [];
    public ICollection<Schedule> Schedules { get; set; } = [];
}