using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int TheaterId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? PlaybillPdf { get; set; }

    public DateTime Datetime { get; set; }

    public int Duration { get; set; }

    public string State { get; set; } = null!;

    public virtual ICollection<EventPriceZone> EventPriceZones { get; set; } = new List<EventPriceZone>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Theater Theater { get; set; } = null!;
}
