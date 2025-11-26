
using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class ReservationService : IReservationService
{
    private readonly TeatroTickets2Context _context;
    public ReservationService(TeatroTickets2Context context)
    {
        _context = context;
    }
    private async Task<decimal> CalculateTotal(List<int> priceZoneSeatIds)
    {
        return await _context.PriceZoneSeats
            .Where(pzs => priceZoneSeatIds.Contains(pzs.PriceZoneSeatId))
            .Select(pzs => pzs.PriceZone.Price)
            .SumAsync();
    }
    private async Task<decimal> FindPriceByPriceZoneSeatId(int priceZoneSeatId)
    {
        return await _context.PriceZoneSeats
            .Where(pzs => pzs.PriceZoneSeatId == priceZoneSeatId)
            .Select(pzs => pzs.PriceZone.Price)
            .FirstOrDefaultAsync();
    }
    private async Task<Ticket> CreateTicket(int reservationId, int priceZoneSeatId, decimal price)
    {
        var newTicket = new Ticket
            {
                ReservationId = reservationId,
                PriceZoneSeatId = priceZoneSeatId,
                Price = price
            };
            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();
        return newTicket;
    }
    private async Task<Reservation> CreateReservation(int? customerId, int performanceId, decimal total)
    {
        var newReservation = new Reservation
        {
            CustomerId = customerId,
            PerformanceId = performanceId,
            Total = total
        };
        _context.Reservations.Add(newReservation);
        await _context.SaveChangesAsync();
        return newReservation;
    }
    private async Task<Payment> CreatePayment(PaymentMethod method, decimal amount)
    {
        if(amount <= 0)
            throw new ArgumentException("La cantidad debe ser positiva");
        
        var newPayment = new Payment
        {
            Method = method,
            Amount = amount
        };
        _context.Payments.Add(newPayment);
        await _context.SaveChangesAsync();
        return newPayment;
    }
    public async Task<bool> BookTickets(BookTicketsDto dto)
    {    
        var newReservation = await CreateReservation(dto.CustomerId, dto.PerformanceId, 0);

        foreach(var seatSelected in dto.PriceZoneSeatIds)
        {
            await CreateTicket(newReservation.ReservationId, seatSelected, 0);
        }

        return true;
    }
    public async Task<bool> PurchaseTickets(PurchaseTicketsDto dto)
    {
        var total = await CalculateTotal(dto.PriceZoneSeatIds);

        if(dto.Amount < total)
            throw new PaymentAmountTooLowException(dto.Amount, total);

        var newReservation = await CreateReservation(dto.CustomerId, dto.PerformanceId, total);
        foreach(var seatSelected in dto.PriceZoneSeatIds)
        {
            var price = await FindPriceByPriceZoneSeatId(seatSelected);
            await CreateTicket(newReservation.ReservationId, seatSelected, price);
        }
        await CreatePayment(dto.Method, dto.Amount);
        return true;
    }
}
