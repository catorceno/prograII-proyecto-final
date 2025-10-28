using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int ReservationId { get; set; }

    public int ButacaId { get; set; }

    public decimal Price { get; set; }

    public virtual Butaca Butaca { get; set; } = null!;

    public virtual Reservation Reservation { get; set; } = null!;
}
