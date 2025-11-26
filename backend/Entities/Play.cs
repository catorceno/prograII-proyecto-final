using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Play
{
    public int PlayId { get; set; }

    public int TheaterId { get; set; }

    public int? PerformerId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? PlaybillPdf { get; set; }

    public int? Duration { get; set; }

    // public string? Category { get; set; }
    public PlayCategory? Category { get; set; }

    // public string State { get; set; } = null!;
    public PlayState State { get; set; }

    public DateTime? DateStartPresale { get; set; }

    public DateTime? DateStartOnsale { get; set; }

    public virtual ICollection<Performance> Performances { get; set; } = new List<Performance>();

    public virtual Performer? Performer { get; set; }

    public virtual Theater Theater { get; set; } = null!;
}
