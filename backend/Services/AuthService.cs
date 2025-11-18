
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

public class AuthService : IAuthService
{
    private readonly TeatroTickets7Context context;
    private readonly IMapper mapper;
    public AuthService(TeatroTickets7Context context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<UserInfoDto> Login(UserDto userDto)
    {
        var userInfo = await context.Users
            .Where(u => u.Email == userDto.Email && u.Password == userDto.Password)
            .ProjectTo<UserInfoDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return userInfo!;
    }
}