namespace SystemManagmentGym.Entities;

public sealed class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;


    public ICollection<UserSchedule> UserSchedules { get; set; } = [];
    public ICollection<UserFitnessClass> FitnessClasses { get; set; } = [];
    public ICollection<Feedback> Feedbacks { get; set; } = [];
    public ICollection<Payment> Payments { get; set; } = [];
}