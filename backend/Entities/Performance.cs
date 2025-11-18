using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Performance
{
    public int PerformanceId { get; set; }

    public DateTime Datetime { get; set; }

    public string State { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
