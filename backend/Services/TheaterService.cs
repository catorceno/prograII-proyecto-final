
using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class TheaterService : ITheaterService
{
    
    private readonly TeatroTickets2Context _context;
    public TheaterService(TeatroTickets2Context context)
    {
        _context = context;
    }
    
    public async Task<bool> RejectRequest(int playId)
    {
        var play = await _context.Plays.FirstOrDefaultAsync(p => p.PlayId == playId);
        if(play != null) play.State = PlayState.Rejected;
        return true;
    }

    public async Task<bool> AcceptRequest(int playId)
    {
        var play = await _context.Plays.FirstOrDefaultAsync(p => p.PlayId == playId);
        if(play != null) play.State = PlayState.Accepted;
        return true;
    }

    public async Task<bool> CancelPlay(int playId)
    {
        var play = await _context.Plays.FirstOrDefaultAsync(p => p.PlayId == playId);
        if(play != null) play.State = PlayState.Canceled;

        var performances = await _context.Performances.Where(p => p.PlayId == playId).ToListAsync();
        foreach(var performance in performances)
        {
            performance.State = PerformanceState.Canceled;
        }
        return true;
    }
    
    public async Task<bool> CancelPerformance(int playId)
    {
        var performance = await _context.Plays.FirstOrDefaultAsync(p => p.PlayId == playId);
        if(performance != null) performance.State = PlayState.Canceled;
        return true;
    }
}