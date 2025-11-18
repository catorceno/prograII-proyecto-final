using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int TheaterId { get; set; }

    public string Day { get; set; } = null!;

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public virtual Theater Theater { get; set; } = null!;
}
