namespace SystemManagmentGym.Entities.Configurations;

public sealed class FitnessClassConfiguration : IEntityTypeConfiguration<FitnessClass>
{
    public void Configure(EntityTypeBuilder<FitnessClass> builder)
    {
        builder.HasIndex(x => x.FitnessName).IsUnique();

        builder.Property(x => x.FitnessName)
            .HasMaxLength(100) 
            .IsRequired() 
            .HasColumnType("varchar");

        builder.Property(x => x.Description)
            .HasMaxLength(500) 
            .IsRequired() 
            .HasColumnType("varchar");

        builder.Property(fc => fc.Price)
            .IsRequired() 
            .HasColumnType("decimal(18,2)");
        
   
        builder.HasMany(fc => fc.Users) 
            .WithOne(uf => uf.FitnessClass) 
            .HasForeignKey(uf => uf.FitnessClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(fc => fc.Schedules)
            .WithOne(s => s.FitnessClass) 
            .HasForeignKey(s => s.FitnessClassId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}