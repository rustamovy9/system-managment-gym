namespace SystemManagmentGym.Entities.Configurations;

public sealed class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnType("varchar");

        builder.HasCheckConstraint("CHK_PhoneNumber_Length", "LENGTH(\"PhoneNumber\") >= 10");

        builder.HasMany(t => t.Feedbacks)
            .WithOne(f => f.Trainer)
            .HasForeignKey(f => f.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Schedules)
            .WithOne(s => s.Trainer)
            .HasForeignKey(s => s.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}