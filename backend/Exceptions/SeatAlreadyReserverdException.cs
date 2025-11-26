
public class SeatAlreadyReservedException : TeatroTicketsException
{
    public SeatAlreadyReservedException(int seatId)
        : base($"El asiento con id {seatId} ya está reservado.")
    {
    }
}
