namespace SystemManagmentGym.Entities.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class UserFitnessClassConfiguration : IEntityTypeConfiguration<UserFitnessClass>
{
    public void Configure(EntityTypeBuilder<UserFitnessClass> builder)
    {
        builder.HasKey(uf => new { uf.UserId, uf.FitnessClassId }); 

        builder.Property(uf => uf.EnrollmentDate)
            .IsRequired(); 

        
        builder.HasOne(uf => uf.User)
            .WithMany(u => u.FitnessClasses)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasOne(uf => uf.FitnessClass)
            .WithMany(fc => fc.Users)
            .HasForeignKey(uf => uf.FitnessClassId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}