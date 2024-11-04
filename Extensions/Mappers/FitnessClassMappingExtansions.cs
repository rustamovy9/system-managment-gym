using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class FitnessClassMappingExtensions
{
    public static FitnessClassReadInfo ToReadInfo(this FitnessClass fitnessClass)
    {
        return new(
            fitnessClass.Id,
            new FitnessClassBaseInfo(
                fitnessClass.FitnessName,
                fitnessClass.Description,
                fitnessClass.Price)
        );
    }

    public static FitnessClass ToFitnessClass(this FitnessClassCreateInfo createInfo)
    {
        return new()
        {
            FitnessName = createInfo.FitnessClassBaseInfo.FitnessName,
            Description = createInfo.FitnessClassBaseInfo.Description,
            Price = createInfo.FitnessClassBaseInfo.Price
        };
    }

    public static FitnessClass ToUpdatedFitnessClass(this FitnessClass fitnessClass, FitnessClassUpdateInfo updateInfo)
    {
        fitnessClass.Id = updateInfo.Id;
        fitnessClass.UpdatedAt = DateTime.UtcNow;
        fitnessClass.Version++;
        fitnessClass.FitnessName = updateInfo.FitnessClassBaseInfo.FitnessName;
        fitnessClass.Description = updateInfo.FitnessClassBaseInfo.Description;
        fitnessClass.Price = updateInfo.FitnessClassBaseInfo.Price;
        return fitnessClass;
    }

    public static FitnessClass ToDeletedFitnessClass(this FitnessClass fitnessClass)
    {
        fitnessClass.IsDeleted = true;
        fitnessClass.DeletedAt = DateTime.UtcNow;
        fitnessClass.UpdatedAt = DateTime.UtcNow;
        fitnessClass.Version++;
        return fitnessClass;
    }
}