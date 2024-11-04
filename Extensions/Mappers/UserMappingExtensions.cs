using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class UserMappingExtensions
{
    public static UserReadInfo ToReadInfo(this User user)
    {
        return new(
            user.Id,
            new UserBaseInfo(
                user.UserName,
                user.FirstName,
                user.LastName,
                user.DateOfBirth,
                user.Email,
                user.PhoneNumber)
        );
    }

    public static User ToUser(this UserCreateInfo createInfo)
    {
        return new()
        {
            UserName = createInfo.UserBaseInfo.UserName,
            Email = createInfo.UserBaseInfo.Email,
            PhoneNumber = createInfo.UserBaseInfo.PhoneNumber,
            FirstName = createInfo.UserBaseInfo.FirstName,
            LastName = createInfo.UserBaseInfo.LastName,
            DateOfBirth = createInfo.UserBaseInfo.DateOfBirth
        };
    }

    public static User ToUpdatedUser(this User user, UserUpdateInfo updateInfo)
    {
        user.UpdatedAt = DateTime.UtcNow;
        user.Version++;
        user.UserName = updateInfo.UserBaseInfo.UserName;
        user.FirstName = updateInfo.UserBaseInfo.FirstName;
        user.LastName = updateInfo.UserBaseInfo.LastName;
        user.DateOfBirth = updateInfo.UserBaseInfo.DateOfBirth;
        user.PhoneNumber = updateInfo.UserBaseInfo.PhoneNumber;
        user.Email = updateInfo.UserBaseInfo.Email;
        return user;
    }

    public static User ToDeletedUser(this User user)
    {
        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        user.Version++;
        return user;
    }
}