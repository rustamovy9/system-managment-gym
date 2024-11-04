namespace SystemManagmentGym.Entities.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class UserScheduleConfiguration : IEntityTypeConfiguration<UserSchedule>
{
    public void Configure(EntityTypeBuilder<UserSchedule> builder)
    {
        builder.Property(us => us.EnrolledAt)
            .IsRequired(); 
        
        builder.Property(us => us.IsPaid)
            .IsRequired(); 


        builder.HasOne(us => us.User)
            .WithMany(u => u.UserSchedules)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasOne(us => us.Schedule)
            .WithMany(s => s.Users)
            .HasForeignKey(us => us.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        
    }
}