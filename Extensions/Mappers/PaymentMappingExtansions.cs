using SystemManagmentGym.DTOs;

namespace SystemManagmentGym.Extensions.Mappers;

public static class PaymentMappingExtensions
{
    public static PaymentReadInfo ToReadInfo(this Payment payment)
    {
        return new(
            payment.Id,
            new PaymentBaseInfo(
                payment.UserId,
                payment.UserScheduleId,
                payment.Amount,
                payment.PaymentDate)
        );
    }

    public static Payment ToPayment(this PaymentCreateInfo createInfo)
    {
        return new()
        {
            UserId = createInfo.PaymentBaseInfo.UserId,
            UserScheduleId = createInfo.PaymentBaseInfo.UserScheduleId,
            Amount = createInfo.PaymentBaseInfo.Amount,
            PaymentDate = createInfo.PaymentBaseInfo.PaymentDate
        };
    }

    public static Payment ToUpdatedPayment(this Payment payment, PaymentUpdateInfo updateInfo)
    {
        payment.Id = updateInfo.Id;
        payment.UpdatedAt = DateTime.UtcNow;
        payment.Version++;
        payment.UserId = updateInfo.PaymentBaseInfo.UserId;
        payment.UserScheduleId = updateInfo.PaymentBaseInfo.UserScheduleId;
        payment.Amount = updateInfo.PaymentBaseInfo.Amount;
        payment.PaymentDate = updateInfo.PaymentBaseInfo.PaymentDate;
        return payment;
    }

    public static Payment ToDeletedPayment(this Payment payment)
    {
        payment.IsDeleted = true;
        payment.DeletedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        payment.Version++;
        return payment;
    }
}