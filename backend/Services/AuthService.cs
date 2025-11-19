
using backend.Entities;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork unitOfWork;

    public AuthService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    private async Task<User> CreateAccount(UserDto userDto, string rol)
    {
        var newUser = new User
        {
            Email = userDto.Email,
            Password = userDto.Password,
            Rol = rol
        };
        await unitOfWork.Repository<User>().Add(newUser);
        await unitOfWork.Save();
        return newUser;
    }
    public async Task<Customer> SigninCustomer(CustomerDto customerDto)
    {
        try
        {
            await unitOfWork.BeginTransaction();
            var newUser = await CreateAccount(customerDto.UserDto, "customer");
            var newCustomer = new Customer
            {
                UserId = newUser.UserId,
                Name = customerDto.Name,
                Phone = customerDto.Phone
            };
            await unitOfWork.Repository<Customer>().Add(newCustomer);
            await unitOfWork.Save();
            await unitOfWork.Commit();

            return newCustomer; 
        }
        catch
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
    public async Task<Performer> SigninPerformer(PerformerDto performerDto)
    {
        try
        {
            var newUser = await CreateAccount(performerDto.UserDto, "performer");
            var newPerformer = new Performer
            {
                UserId = newUser.UserId,
                Name = performerDto.Name,
                Type = performerDto.Type,
                Contact = performerDto.Contact,
                Address = performerDto.Address
            };
            await unitOfWork.Repository<Performer>().Add(newPerformer);
            await unitOfWork.Save();
            await unitOfWork.Commit();

            return newPerformer;
        }
        catch
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
    public async Task<UserInfoDto> Login(UserDto userDto)
    {
        var user = await unitOfWork.Repository<User>().FirstOrDefault(u => u.Email == userDto.Email && u.Password == userDto.Password);
        var userInfoDto = new UserInfoDto
        {
            UserId = user.UserId,
            Email = user.Email,
            Rol = user.Rol
        };
        return userInfoDto;
    }
}
/*
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
    private async Task<User> CreateUser(UserDto userDto, string rol)
    {
        if (userDto.Password.Length < 8)
            throw new Exception("Al menos 8 carácteres");

        var newUser = new User
        {
            Email = userDto.Email,
            Password = userDto.Password,
            Rol = rol
        };
        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        return newUser;
    }

    public async Task<Customer> SigninCustomer(CustomerDto customerDto)
    {
        if (customerDto.Phone.Length < 8)
            throw new Exception("Número de teléfono inválido");
        
        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                var newUser = await CreateUser(customerDto.UserDto, "customer");
                var newCustomer = new Customer
                {
                    UserId = newUser.UserId,
                    Name = customerDto.Name,
                    Phone = customerDto.Phone
                };
                context.Customers.Add(newCustomer);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
                return newCustomer;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("rollback sign in customer", ex);
            }
        }
    }
    
    public async Task<Performer> SigninPerformer(PerformerDto performerDto)
    {
        // validar entradas
        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                var newUser = await CreateUser(performerDto.UserDto, "performer");
                var newPerformer = new Performer
                {
                    UserId = newUser.UserId,
                    Name = performerDto.Name,
                    Contact = performerDto.Contact,
                    Type = performerDto.Type,
                    Address = performerDto.Address
                };
                context.Performers.Add(newPerformer);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
                return newPerformer;
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("rollback sign in performer", ex);
            }
        }
    }
}
*/