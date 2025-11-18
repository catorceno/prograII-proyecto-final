using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Seat
{
    public int SeatId { get; set; }

    public int RowId { get; set; }

    public int Column { get; set; }

    public int Number { get; set; }

    public string Side { get; set; } = null!;

    public virtual ICollection<PriceZoneSeat> PriceZoneSeats { get; set; } = new List<PriceZoneSeat>();

    public virtual Row Row { get; set; } = null!;
}
