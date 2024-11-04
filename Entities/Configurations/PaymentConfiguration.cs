namespace SystemManagmentGym.Entities.Configurations;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        builder.HasOne(p => p.User)
            .WithMany(u => u.Payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(p => p.UserSchedule)
            .WithOne() 
            .HasForeignKey<Payment>(p => p.UserScheduleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}