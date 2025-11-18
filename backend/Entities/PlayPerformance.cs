using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class PlayPerformance
{
    public int PlayId { get; set; }

    public int PerformanceId { get; set; }

    public virtual Performance Performance { get; set; } = null!;

    public virtual Play Play { get; set; } = null!;
}
