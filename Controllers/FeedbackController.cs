using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Services.FeedbackServices;

namespace SystemManagmentGym.Controllers;

[Route("api/feedback")] 
public class FeedbackController(IFeedbackService feedbackService) : BaseController
{
[HttpGet]
    public async Task<IActionResult> Get([FromQuery] FeedbackFilter filter)
        => (await feedbackService.GetFeedbackAsync(filter)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await feedbackService.GetFeedbackByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FeedbackCreateInfo info)
        => (await feedbackService.CreateFeedbackAsync(info)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] FeedbackUpdateInfo info)
        => (await feedbackService.UpdateFeedbackAsync(id,info)).ToActionResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => (await feedbackService.DeleteFeedbackAsync(id)).ToActionResult();
}
