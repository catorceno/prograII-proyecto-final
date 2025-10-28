using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Theater
{
    public int TheaterId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<SeatingArea> SeatingAreas { get; set; } = new List<SeatingArea>();

    public virtual User User { get; set; } = null!;
}
