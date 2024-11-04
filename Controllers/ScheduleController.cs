using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Services.ScheduleServices;

namespace SystemManagmentGym.Controllers;

[Route("api/schedule")]
public class ScheduleController(IScheduleService scheduleService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ScheduleFilter filter)
        => (await scheduleService.GetScheduleAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await scheduleService.GetScheduleByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ScheduleCreateInfo info)
        => (await scheduleService.CreateScheduleAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] ScheduleUpdateInfo info)
        => (await scheduleService.UpdateScheduleAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await scheduleService.DeleteScheduleAsync(id)).ToActionResult();
}