using SystemManagmentGym.Extensions.EFCore;

namespace SystemManagmentGym.DataContext;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<FitnessClass> FitnessClasses { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<UserFitnessClass> UserFitnessClasses { get; set; }
    public DbSet<UserSchedule> UserSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}