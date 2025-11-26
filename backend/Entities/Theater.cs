using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Theater
{
    public int TheaterId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Play> Plays { get; set; } = new List<Play>();

    public virtual ICollection<Row> Rows { get; set; } = new List<Row>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual User User { get; set; } = null!;
}
