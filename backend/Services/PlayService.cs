
using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class PlayService : IPlayService
{
    private readonly TeatroTickets2Context _context;
    public PlayService(TeatroTickets2Context context)
    {
        _context = context;
    }

    public async Task<int> Create(PlayCreateDto playDto)
    {
        var newPlay = new Play
        {
            TheaterId = 1,
            PerformerId = playDto.PerformerId,
            Title = playDto.Title,
            Description = playDto.Description,
            PlaybillPdf = playDto.PlaybillPdf,
            Duration = playDto.Duration,
            Category = playDto.Category,
            DateStartPresale = playDto.DateStartPresale,
            DateStartOnsale = playDto.DateStartOnsale
        };
        _context.Plays.Add(newPlay);
        await _context.SaveChangesAsync();
        return newPlay.PlayId;
    }

    public async Task<List<PlayDto>> GetAllPublished()
    {
        return await _context.Plays
            .Where(p => p.State == PlayState.Published)
            .Select(p => new PlayDto
            {
                PlayId = p.PlayId,
                PerformerName = p.Performer!.Name,
                Title = p.Title!,
                Duration = p.Duration!.Value,
                Category = p.Category!.Value
            })
            .ToListAsync();
    }
    public async Task<PlayDetailsDto?> GetPublishedById(int id)
    {
        return await _context.Plays
            .Where(p => p.PlayId == id && p.State == PlayState.Published)
            .Select(p => new PlayDetailsDto
            {
                PlayId = p.PlayId,
                PerformerName = p.Performer!.Name,
                Title = p.Title!,
                Duration = p.Duration!.Value,
                Category = p.Category!.Value,
                Description = p.Description!,
                PlaybillPdf = p.PlaybillPdf!
            })
            .FirstOrDefaultAsync();
    }
}