using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Performer
{
    public int PerformerId { get; set; }

    public int? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Contact { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Play> Plays { get; set; } = new List<Play>();

    public virtual User? User { get; set; }
}
