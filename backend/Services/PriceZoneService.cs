
using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class PriceZoneService : IPriceZoneService
{
    private readonly TeatroTickets2Context _context;
    public PriceZoneService(TeatroTickets2Context context)
    {
        _context = context;
    }
    
    public async Task CreateByPlayId(PriceZoneCreateDto priceZoneDto)
    {
        var performanceIds = await _context.Performances
                                .Where(p => p.PlayId == priceZoneDto.PlayId)
                                .Select(p => p.PerformanceId)
                                .ToListAsync();
        
        foreach(var performanceId in performanceIds)
        {
            Console.WriteLine("hey, id = " + performanceId);
            var newPriceZone = new PriceZone
            {
                PerformanceId = performanceId,
                Name = priceZoneDto.Name,
                PricePresale = priceZoneDto.PricePresale,
                Price = priceZoneDto.Price
            };
            _context.PriceZones.Add(newPriceZone);
            await _context.SaveChangesAsync();

            var seatIds = await _context.Seats
                            .Where(s => s.SeatId >= priceZoneDto.FromSeatId && s.SeatId <= priceZoneDto.ToSeatId)
                            .Select(s => s.SeatId)
                            .ToListAsync();
            
            foreach(var seatId in seatIds)
            {
                var newPriceZoneSeat = new PriceZoneSeat
                {
                    PriceZoneId = newPriceZone.PriceZoneId,
                    SeatId = seatId
                };
                _context.PriceZoneSeats.Add(newPriceZoneSeat);
                await _context.SaveChangesAsync();
            }        
        }
    }
}