using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Butaca
{
    public int ButacaId { get; set; }

    public int SeatingAreaId { get; set; }

    public string Row { get; set; } = null!;

    public int Number { get; set; }

    public string State { get; set; } = null!;

    public virtual ICollection<EventPriceZoneSeat> EventPriceZoneSeats { get; set; } = new List<EventPriceZoneSeat>();

    public virtual SeatingArea SeatingArea { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
