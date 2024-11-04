using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;

namespace SystemManagmentGym.Controllers;

[Route("api/user-schedules")]
public sealed class UserScheduleController(IUserScheduleService userScheduleService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserScheduleFilter filter)
        => (await userScheduleService.GetUserScheduleAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await userScheduleService.GetUserScheduleByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserScheduleCreateInfo info)
        => (await userScheduleService.CreateUserScheduleAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UserScheduleUpdateInfo info)
        => (await userScheduleService.UpdateUserScheduleAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await userScheduleService.DeleteUserScheduleAsync(id)).ToActionResult();
}