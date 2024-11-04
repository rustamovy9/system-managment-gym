namespace SystemManagmentGym.DTOs;

public readonly record struct UserFitnessClassBaseInfo(
    int UserId,
    int FitnessClassId,
    DateTime EnrollmentDate);

public readonly record struct UserFitnessClassReadInfo(
    int Id,
    UserFitnessClassBaseInfo UserFitnessClassBaseInfo,
    UserReadInfo UserReadInfo,
    FitnessClassReadInfo FitnessClassReadInfo);

public readonly record struct UserFitnessClassCreateInfo(
    UserFitnessClassBaseInfo UserFitnessClassBaseInfo);

public readonly record struct UserFitnessClassUpdateInfo(
    int Id,
    UserFitnessClassBaseInfo UserFitnessClassBaseInfo);