using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Event
{
    public int EventId { get; set; }

    public int TheaterId { get; set; }

    public int? PerformerId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? PlaybillPdf { get; set; }

    public string Category { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual Performer? Performer { get; set; }

    public virtual ICollection<Play> Plays { get; set; } = new List<Play>();

    public virtual Theater Theater { get; set; } = null!;
}
