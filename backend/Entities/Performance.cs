using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Performance
{
    public int PerformanceId { get; set; }

    public int PlayId { get; set; }

    public DateTime Datetime { get; set; }

    // public string State { get; set; } = null!;
    public PerformanceState State { get; set; }

    public virtual Play Play { get; set; } = null!;

    public virtual ICollection<PriceZone> PriceZones { get; set; } = new List<PriceZone>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
