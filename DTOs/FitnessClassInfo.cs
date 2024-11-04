
namespace SystemManagmentGym.DTOs;

public readonly record struct FitnessClassBaseInfo(
    string FitnessName,
    string Description,
    decimal Price);

public readonly record struct FitnessClassReadInfo(
    int Id,
    FitnessClassBaseInfo FitnessClassBaseInfo);

public readonly record struct FitnessClassCreateInfo(
    FitnessClassBaseInfo FitnessClassBaseInfo);

public readonly record struct FitnessClassUpdateInfo(
    int Id,
    FitnessClassBaseInfo FitnessClassBaseInfo);