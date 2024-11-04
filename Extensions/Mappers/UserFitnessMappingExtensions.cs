using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class UserFitnessClassMappingExtensions
{
    public static UserFitnessClassReadInfo ToReadInfo(this UserFitnessClass userFitnessClass)
    {
        return new UserFitnessClassReadInfo()
        {
            Id = userFitnessClass.Id,
            FitnessClassReadInfo = userFitnessClass.FitnessClass.ToReadInfo(),
            UserReadInfo = userFitnessClass.User.ToReadInfo(),
            UserFitnessClassBaseInfo = new()
            {
                FitnessClassId = userFitnessClass.FitnessClassId,
                UserId = userFitnessClass.UserId,
                EnrollmentDate = userFitnessClass.EnrollmentDate
            }
        };
    }

    public static UserFitnessClass ToUserFitnessClass(this UserFitnessClassCreateInfo createInfo)
    {
        return new()
        {
            FitnessClassId = createInfo.UserFitnessClassBaseInfo.FitnessClassId,
            UserId = createInfo.UserFitnessClassBaseInfo.UserId,
            EnrollmentDate = createInfo.UserFitnessClassBaseInfo.EnrollmentDate
        };
    }

    public static UserFitnessClass ToUpdatedUserFitnessClass(this UserFitnessClass userFitnessClass, UserFitnessClassUpdateInfo updateInfo)
    {
        userFitnessClass.FitnessClassId = updateInfo.UserFitnessClassBaseInfo.FitnessClassId;
        userFitnessClass.UserId = updateInfo.UserFitnessClassBaseInfo.UserId;
        userFitnessClass.EnrollmentDate = updateInfo.UserFitnessClassBaseInfo.EnrollmentDate;
        userFitnessClass.UpdatedAt = DateTime.UtcNow;
        userFitnessClass.Version++;
        return userFitnessClass;
    }

    public static UserFitnessClass ToDeletedUserFitnessClass(this UserFitnessClass userFitnessClass)
    {
        userFitnessClass.DeletedAt = DateTime.UtcNow;
        userFitnessClass.IsDeleted = true;
        userFitnessClass.UpdatedAt = DateTime.UtcNow;
        userFitnessClass.Version++;
        return userFitnessClass;
    }
}