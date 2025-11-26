
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IPerformerService _performerService;
    public UserController(IPerformerService performerService)
    {
        _performerService = performerService;
    }

    [HttpPost("signin-performer")]
    public async Task<IActionResult> SigninPerformer([FromBody] PerformerCreateDto performerDto)
    {
        int newPerformerId = await _performerService.Signin(performerDto);
        return Ok($"yes: {newPerformerId}");
    }
}