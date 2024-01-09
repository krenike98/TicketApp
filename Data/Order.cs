using System;
using System.Collections.Generic;

namespace TicketApp.Data;

public partial class Order
{
    public int LineId { get; set; }

    public int UserId { get; set; }

    public int DepartureTimeId { get; set; }

    public virtual Departuretime DepartureTime { get; set; } = null!;

    public virtual Line Line { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
