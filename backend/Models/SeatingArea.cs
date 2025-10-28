using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class SeatingArea
{
    public int SeatingAreaId { get; set; }

    public int TheaterId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Butaca> Butacas { get; set; } = new List<Butaca>();

    public virtual Theater Theater { get; set; } = null!;
}
