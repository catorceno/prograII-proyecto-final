using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Row
{
    public int RowId { get; set; }

    public int TheaterId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual Theater Theater { get; set; } = null!;
}
