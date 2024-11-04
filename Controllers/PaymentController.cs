using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Services.PaymentServices;

namespace SystemManagmentGym.Controllers;

[Route("api/payment")]
public class PaymentController(IPaymentService paymentService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaymentFilter filter)
        => (await paymentService.GetPaymentsAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await paymentService.GetPaymentByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentCreateInfo info)
        => (await paymentService.CreatePaymentAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] PaymentUpdateInfo info)
        => (await paymentService.UpdatePaymentAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await paymentService.DeletePaymentAsync(id)).ToActionResult();
}