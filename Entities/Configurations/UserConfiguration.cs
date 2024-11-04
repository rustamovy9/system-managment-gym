namespace SystemManagmentGym.Entities.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();
        builder.HasIndex(x => x.UserName).IsUnique();

        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.UserName)
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired()
            .HasColumnType("varchar");
        
        builder.HasCheckConstraint("CHK_PhoneNumber_Length", "LENGTH(\"PhoneNumber\") >= 10");
        
        builder.HasMany(u => u.UserSchedules)
            .WithOne(us => us.User)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasMany(u => u.FitnessClasses)
            .WithOne(uf => uf.User)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Feedbacks)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Payments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}