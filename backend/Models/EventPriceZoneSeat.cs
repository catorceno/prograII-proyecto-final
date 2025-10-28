using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class EventPriceZoneSeat
{
    public int PriceZoneSeatId { get; set; }

    public int PriceZoneId { get; set; }

    public int ButacaId { get; set; }

    public virtual Butaca Butaca { get; set; } = null!;

    public virtual EventPriceZone PriceZone { get; set; } = null!;
}
