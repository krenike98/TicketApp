using System;
using System.Collections.Generic;

namespace TicketApp.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public string? Adress { get; set; }

    public string? PhoneNumber { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
