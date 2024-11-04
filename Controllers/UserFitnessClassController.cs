using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Services.UserFitnessClassServices;

namespace SystemManagmentGym.Controllers;

[Route("api/user-fitness-class")]
public class UserFitnessClassController(IUserFitnessClassService userFitnessClassService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFitnessClassFilter filter)
        => (await userFitnessClassService.GetUserFitnessClassAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await userFitnessClassService.GetUserFitnessClassByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserFitnessClassCreateInfo info)
        => (await userFitnessClassService.CreateUserFitnessClassAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UserFitnessClassUpdateInfo info)
        => (await userFitnessClassService.UpdateUserFitnessClassAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await userFitnessClassService.DeleteUserFitnessClassAsync(id)).ToActionResult();
}