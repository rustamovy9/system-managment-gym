namespace SystemManagmentGym.Entities;

public sealed class FitnessClass : BaseEntity
{
    public string FitnessName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }


    public ICollection<UserFitnessClass> Users { get; set; } = [];
    public ICollection<Schedule> Schedules { get; set; } = [];
}