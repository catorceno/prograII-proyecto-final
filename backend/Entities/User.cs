using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Performer> Performers { get; set; } = new List<Performer>();

    public virtual ICollection<Theater> Theaters { get; set; } = new List<Theater>();
}
