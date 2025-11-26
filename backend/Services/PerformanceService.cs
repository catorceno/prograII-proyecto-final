
using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class PerformanceService : IPerformanceService
{
    private readonly TeatroTickets2Context _context;
    public PerformanceService(TeatroTickets2Context context)
    {
        _context = context;
    }

    public async Task<int> Create(PerformanceCreateDto performanceDto)
    {
        var newPerformance = new Performance
        {
            PlayId = performanceDto.PlayId,
            Datetime = performanceDto.Datetime
        };
        _context.Performances.Add(newPerformance);
        await _context.SaveChangesAsync();
        return newPerformance.PerformanceId;
    }

    public async Task<List<PerformanceDto>> GetAllByPlayId(int playId)
    {
        return await _context.Performances
            .Where(p => p.PlayId == playId)
            .Select(p => new PerformanceDto
            {
                PerformanceId = p.PerformanceId,
                Datetime = p.Datetime
            })
            .ToListAsync();
    }

    public async Task<PerformanceDto?> GetById(int id)
    {
        return await _context.Performances
            .Where(p => p.PerformanceId == id)
            .Select(p => new PerformanceDto
            {
                PerformanceId = p.PerformanceId,
                Datetime = p.Datetime
            })
            .FirstOrDefaultAsync();
    }

    public async Task<PerformanceSeatingPlanDto> GetSeatingPlanByPerformanceId(int performanceId)
    {
        var priceZones = await _context.PriceZones
            .Where(pz => pz.PerformanceId == performanceId)
            .Select(pz => new PriceZoneDto
            {
                PriceZoneId = pz.PriceZoneId,
                Name = pz.Name,
                Price = pz.Price,
                RowDtos = pz.PriceZoneSeats
                    .GroupBy(pzs => new { pzs.Seat.Row.RowId, pzs.Seat.Row.Name })
                    .Select(g => new RowDto
                    {
                        RowId = g.Key.RowId,
                        Name = g.Key.Name,
                        PriceZoneSeatsDto = g.Select(pzs => new PriceZoneSeatDto
                        {
                            PriceZoneSeatId = pzs.PriceZoneSeatId,
                            State = pzs.State,
                            Column = pzs.Seat.Column,
                            Number = pzs.Seat.Number,
                            Side = pzs.Seat.Side
                        }).ToList()
                    }).ToList()
            })
            .ToListAsync();

        return new PerformanceSeatingPlanDto { PriceZoneDtos = priceZones };
    }
}