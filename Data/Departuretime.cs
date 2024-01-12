using System;
using System.Collections.Generic;

namespace TicketApp.Data;

public partial class Departuretime
{
    public int DepartureTimeId { get; set; }

    public int LineId { get; set; }

    public DateTime Departure { get; set; }

    public virtual Line Line { get; set; } = null!;

    public virtual ICollection<Ticket> Orders { get; } = new List<Ticket>();
}
