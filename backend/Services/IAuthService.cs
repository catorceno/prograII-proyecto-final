
using backend.Entities;

public interface IAuthService
{
    Task<UserInfoDto> Login(UserDto userDto);
}