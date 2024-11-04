namespace SystemManagmentGym.DTOs;
public readonly record struct UserBaseInfo(
    string UserName,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Email,
    string PhoneNumber);

public readonly record struct UserReadInfo(
    int UserId,
    UserBaseInfo UserBaseInfo);

public readonly record struct UserCreateInfo(
    UserBaseInfo UserBaseInfo);

public readonly record struct UserUpdateInfo(
    int UserId,
    UserBaseInfo UserBaseInfo);