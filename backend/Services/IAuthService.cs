
using backend.Entities;

public interface IAuthService
{
    Task<UserInfoDto> Login(UserDto userDto);
    Task<Customer> SigninCustomer(CustomerDto customerDto);
    Task<Performer> SigninPerformer(PerformerDto performerDto);
}