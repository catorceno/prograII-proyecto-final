using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class EventPriceZone
{
    public int PriceZoneId { get; set; }

    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<EventPriceZoneSeat> EventPriceZoneSeats { get; set; } = new List<EventPriceZoneSeat>();
}
