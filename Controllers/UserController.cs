using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;

namespace SystemManagmentGym.Controllers;

[Route("api/users")]
public sealed class UserController(IUserService userService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFilter filter)
        => (await userService.GetUserAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await userService.GetUserByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateInfo info)
        => (await userService.CreateUserAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UserUpdateInfo info)
        => (await userService.UpdateUserAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await userService.DeleteUserAsync(id)).ToActionResult();
}