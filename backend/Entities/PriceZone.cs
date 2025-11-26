using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class PriceZone
{
    public int PriceZoneId { get; set; }

    public int PerformanceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? PricePresale { get; set; }

    public decimal Price { get; set; }

    public virtual Performance Performance { get; set; } = null!;

    public virtual ICollection<PriceZoneSeat> PriceZoneSeats { get; set; } = new List<PriceZoneSeat>();
}
