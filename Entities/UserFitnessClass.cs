namespace SystemManagmentGym.Entities;

public sealed class UserFitnessClass : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int FitnessClassId { get; set; }
    public FitnessClass FitnessClass { get; set; }

    public DateTime EnrollmentDate { get; set; }
}