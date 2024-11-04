using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Services.TrainerServices;

namespace SystemManagmentGym.Controllers;

[Route("/api/trainers")]
public sealed class TrainerController(ITrainerService trainerService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] TrainerFilter filter)
        => (await trainerService.GetTrainerAsync(filter)).ToActionResult();


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await trainerService.GetTrainerByIdAsync(id)).ToActionResult();


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TrainerCreateInfo info)
        => (await trainerService.CreateTrainerAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody] TrainerUpdateInfo info)
        => (await trainerService.UpdateTrainerAsync(id,info)).ToActionResult();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await trainerService.DeleteTrainerAsync(id)).ToActionResult();
}