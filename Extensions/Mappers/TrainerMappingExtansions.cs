using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class TrainerMappingExtensions
{
    public static TrainerReadInfo ToReadInfo(this Trainer trainer)
    {
        return new(
            trainer.Id,
            new TrainerBaseInfo(
                trainer.FirstName,
                trainer.LastName,
                trainer.Email,
                trainer.PhoneNumber,
                trainer.Specialization,
                trainer.MonthSalary,
                trainer.BonusSalary));
}

    public static Trainer ToTrainer(this TrainerCreateInfo createInfo)
    {
        return new()
        {
            Email = createInfo.TrainerBaseInfo.Email,
            PhoneNumber = createInfo.TrainerBaseInfo.PhoneNumber,
            FirstName = createInfo.TrainerBaseInfo.FirstName,
            LastName = createInfo.TrainerBaseInfo.LastName,
            Specialization = createInfo.TrainerBaseInfo.Specialization,
            MonthSalary = createInfo.TrainerBaseInfo.MonthSalary,
            BonusSalary = createInfo.TrainerBaseInfo.BonusSalary
        };
    }

    public static Trainer ToUpdatedTrainer(this Trainer trainer, TrainerUpdateInfo updateInfo)
    {
        trainer.Id = updateInfo.Id;
        trainer.UpdatedAt = DateTime.UtcNow;
        trainer.Version++;
        trainer.FirstName = updateInfo.TrainerBaseInfo.FirstName;
        trainer.LastName = updateInfo.TrainerBaseInfo.LastName;
        trainer.PhoneNumber = updateInfo.TrainerBaseInfo.PhoneNumber;
        trainer.Email = updateInfo.TrainerBaseInfo.Email;
        trainer.Specialization = updateInfo.TrainerBaseInfo.Specialization;
        trainer.MonthSalary = updateInfo.TrainerBaseInfo.MonthSalary;
        trainer.BonusSalary = updateInfo.TrainerBaseInfo.BonusSalary;
        return trainer;
    }

    public static Trainer ToDeletedTrainer(this Trainer trainer)
    {
        trainer.IsDeleted = true;
        trainer.DeletedAt = DateTime.UtcNow;
        trainer.UpdatedAt = DateTime.UtcNow;
        trainer.Version++;
        return trainer;
    }
}