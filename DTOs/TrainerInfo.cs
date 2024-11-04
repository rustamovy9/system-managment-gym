namespace SystemManagmentGym.DTOs;

public readonly record struct TrainerBaseInfo(
    string FirstName, 
    string LastName,
    string Email,
    string PhoneNumber,
    string Specialization,
    decimal MonthSalary,
    decimal BonusSalary);
    

public readonly record struct TrainerReadInfo(
    int Id,
    TrainerBaseInfo TrainerBaseInfo);

public readonly record struct TrainerCreateInfo(
    TrainerBaseInfo TrainerBaseInfo);

public readonly record struct TrainerUpdateInfo(
    int Id,
    TrainerBaseInfo TrainerBaseInfo);
