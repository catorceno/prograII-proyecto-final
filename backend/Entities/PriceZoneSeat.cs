using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class PriceZoneSeat
{
    public int PriceZoneSeatId { get; set; }

    public int PriceZoneId { get; set; }

    public int SeatId { get; set; }

    public string State { get; set; } = null!;

    public virtual PriceZone PriceZone { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
