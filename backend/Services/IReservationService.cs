
public interface IReservationService
{
    Task<bool> BookTickets(BookTicketsDto dto);
    Task<bool> PurchaseTickets(PurchaseTicketsDto dto);
}