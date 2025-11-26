
using backend.Entities;

public class PerformerService : IPerformerService
{
    private readonly TeatroTickets2Context _context;
    public PerformerService(TeatroTickets2Context context)
    {
        _context = context;
    }

    public async Task<int> Signin(PerformerCreateDto performerDto)
    {
        var newUser = new User
        {
            Email = performerDto.Email,
            Password = performerDto.Password,
            Rol = "performer"
        };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        var newPerformer = new Performer
        {
            UserId = newUser.UserId,
            Name = performerDto.Name,
            Address = performerDto.Address,
            Contact = performerDto.Contact,
            Type = performerDto.Type
        };
        _context.Performers.Add(newPerformer);
        await _context.SaveChangesAsync();

        return newPerformer.PerformerId;
    }
}