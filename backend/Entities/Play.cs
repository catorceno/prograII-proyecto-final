using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Play
{
    public int PlayId { get; set; }

    public int EventId { get; set; }

    public int PerformerId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Duration { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Performer Performer { get; set; } = null!;
}
