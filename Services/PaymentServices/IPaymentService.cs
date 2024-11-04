using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.PaymentServices;

public interface IPaymentService
{
    Task<Result<PagedResponse<IEnumerable<PaymentReadInfo>>>> GetPaymentsAsync(PaymentFilter filter);
    Task<Result<PaymentReadInfo>> GetPaymentByIdAsync(int paymentId);
    Task<BaseResult> CreatePaymentAsync(PaymentCreateInfo createInfo);
    Task<BaseResult> UpdatePaymentAsync(int id, PaymentUpdateInfo updateInfo);
    Task<BaseResult> DeletePaymentAsync(int paymentId);
}