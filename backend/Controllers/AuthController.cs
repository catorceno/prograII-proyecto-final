
using Microsoft.AspNetCore.Mvc;

[ApiController]
// [Route("api/[controller]")]
[Route("api")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<UserInfoDto> Login([FromBody] UserDto userDto)
    {
        var user = await authService.Login(userDto);
        return user;
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SigninCustomer([FromBody] CustomerDto customerDto)
    {
        try
        {
            var customer = await authService.SigninCustomer(customerDto);
            return Ok("yes: " + customer);
        }
        catch (Exception ex)
        {
            return NotFound("no: " + ex);
        }
    }

    [HttpPost("signin-performer")]
    public async Task<IActionResult> SigninPerformer([FromBody] PerformerDto performerDto)
    {
        try
        {
            var performer = await authService.SigninPerformer(performerDto);
            return Ok("yes: " + performer);
        }
        catch (Exception ex)
        {
            return NotFound("no: " + ex);
        }
    }
}