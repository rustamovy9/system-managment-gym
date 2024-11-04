// namespace SystemManagmentGym.Entities.Configurations;
//
// public sealed class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
// {
//     public void Configure(EntityTypeBuilder<Schedule> builder)
//     {
//         builder.Property(s => s.StartDateTime)
//             .HasColumnType("timestamp with time zone")
//             .IsRequired();
//
//         builder.Property(s => s.EndDateTime)
//             .HasColumnType("timestamp with time zone")
//             .IsRequired();
//
//         builder.HasIndex(s => new { s.FitnessClassId, s.TrainerId, s.StartDateTime})
//             .IsUnique();
//
//         builder.HasCheckConstraint("CHK_Start_End_DateTime", "StartDateTime < EndDateTime");
//         
//         builder.HasOne(s => s.FitnessClass)
//             .WithMany(fc => fc.Schedules)
//             .HasForeignKey(s => s.FitnessClassId)
//             .OnDelete(DeleteBehavior.Cascade);
//
//         builder.HasOne(s => s.Trainer)
//             .WithMany(t => t.Schedules)
//             .HasForeignKey(s => s.TrainerId)
//             .OnDelete(DeleteBehavior.Cascade); 
//
//         builder.HasMany(s => s.Users)
//             .WithOne(us => us.Schedule)
//             .HasForeignKey(us => us.ScheduleId)
//             .OnDelete(DeleteBehavior.Cascade); 
//     }
// }