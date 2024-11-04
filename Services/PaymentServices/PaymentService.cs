using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.PaymentServices;

public sealed class PaymentService(DataContext.DataContext context) : IPaymentService
{
    public async Task<Result<PagedResponse<IEnumerable<PaymentReadInfo>>>> GetPaymentsAsync(PaymentFilter filter)
    {
        IQueryable<Payment> payments = context.Payments;

        if (filter.PaymentDate is not null)
            payments = payments.Where(p => p.PaymentDate == filter.PaymentDate);
        
        int totalRecords = await payments.CountAsync();

        IQueryable<PaymentReadInfo> result = payments
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());

        PagedResponse<IEnumerable<PaymentReadInfo>> response = PagedResponse<IEnumerable<PaymentReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<PaymentReadInfo>>>.Success(response);
    }

    public async Task<Result<PaymentReadInfo>> GetPaymentByIdAsync(int paymentId)
    {
        Payment? payment = await context.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);

        return payment is null
            ? Result<PaymentReadInfo>.Failure(Error.NotFound())
            : Result<PaymentReadInfo>.Success(payment.ToReadInfo());
    }

    public async Task<BaseResult> CreatePaymentAsync(PaymentCreateInfo createInfo)
    {
        await context.Payments.AddAsync(createInfo.ToPayment());
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data was not saved!!!"));
    }

    public async Task<BaseResult> UpdatePaymentAsync(int id, PaymentUpdateInfo updateInfo)
    {
        Payment? existingPayment = await context.Payments.AsTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (existingPayment is null)
            return BaseResult.Failure(Error.NotFound());

        existingPayment.ToUpdatedPayment(updateInfo);
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data was not updated!!!"));
    }

    public async Task<BaseResult> DeletePaymentAsync(int paymentId)
    {
        Payment? existingPayment = await context.Payments.AsTracking().FirstOrDefaultAsync(p => p.Id == paymentId);
        if (existingPayment is null)
            return BaseResult.Failure(Error.NotFound());

        context.Payments.Remove(existingPayment);
        int res = await context.SaveChangesAsync();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data was not deleted!!!"));
    }
}
