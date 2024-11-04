using System.ComponentModel.DataAnnotations.Schema;

namespace SystemManagmentGym.Entities;

public sealed class Schedule : BaseEntity
{
    public int FitnessClassId { get; set; }
    public int TrainerId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    
    public FitnessClass FitnessClass { get; set; }
    public Trainer Trainer { get; set; }
    public ICollection<UserSchedule> Users { get; set; } = [];

}