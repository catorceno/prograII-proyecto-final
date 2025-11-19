

using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class SeatingPlanRepository : ISeatingPlanRepository
{
    private readonly TeatroTickets7Context context;
    public SeatingPlanRepository(TeatroTickets7Context context)
    {
        this.context = context;
    }
    public async Task<List<Row>> GetRowWithSeatByTheaterId(int theaterId)
    {
        return await context.Rows.Where(r => r.TheaterId == theaterId).Include(r => r.Seats).OrderBy(r => r.Name).ToListAsync();
    }
}