using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? UserId { get; set; }

    public int EventId { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User? User { get; set; }
}
