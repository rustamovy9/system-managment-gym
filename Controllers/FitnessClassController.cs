using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Services.FitnessClassServices;

namespace SystemManagmentGym.Controllers;

[Route("api/fitness-class")]
public sealed class FitnessClassController(IFitnessClassService fitnessClassService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FitnessClassFilter filter)
        => (await fitnessClassService.GetFitnessClassesAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await fitnessClassService.GetFitnessClassByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FitnessClassCreateInfo info)
        => (await fitnessClassService.CreateFitnessClassAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] FitnessClassUpdateInfo info)
        => (await fitnessClassService.UpdateFitnessClassAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await fitnessClassService.DeleteFitnessClassAsync(id)).ToActionResult();
}