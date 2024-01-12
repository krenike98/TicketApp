using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TicketApp.Data;

public partial class Ticket
{
    public int LineId { get; set; }

    public string Id { get; set; }

    public int DepartureTimeId { get; set; }

    public virtual Departuretime DepartureTime { get; set; } = null!;

    public virtual Line Line { get; set; } = null!;

    public virtual IdentityUser User { get; set; } = null!;
}
