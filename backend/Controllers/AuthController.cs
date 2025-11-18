
using backend.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
// [Route("api/[controller]")]
[Route("api")]
public class AuthController
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
}