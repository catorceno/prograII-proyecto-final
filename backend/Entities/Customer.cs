using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User User { get; set; } = null!;
}
