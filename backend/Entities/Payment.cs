using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int ReservationId { get; set; }

    public string Method { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;
}
