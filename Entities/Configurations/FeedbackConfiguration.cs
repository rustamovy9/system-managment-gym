namespace SystemManagmentGym.Entities.Configurations;

public sealed class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasIndex(f => new { f.UserId, f.TrainerId })
            .IsUnique();

        builder.Property(f => f.Comment)
            .HasMaxLength(500) 
            .IsRequired(false) 
            .HasColumnType("varchar");

        builder.Property(f => f.Rating)
            .IsRequired()
            .HasColumnType("int");

        builder.HasOne(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(f => f.Trainer) 
            .WithMany(t => t.Feedbacks) 
            .HasForeignKey(f => f.TrainerId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}