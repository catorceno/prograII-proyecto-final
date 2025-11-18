using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int ReservationId { get; set; }

    public int PriceZoneSeatId { get; set; }

    public int Price { get; set; }

    public virtual PriceZoneSeat PriceZoneSeat { get; set; } = null!;

    public virtual Reservation Reservation { get; set; } = null!;
}
