namespace SystemManagmentGym.Entities;

public sealed class Feedback : BaseEntity
{
    public int UserId { get; set; }
    public int TrainerId { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
    
    
    public User User { get; set; }
    public Trainer Trainer { get; set; }
}