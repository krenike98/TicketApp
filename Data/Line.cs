using System;
using System.Collections.Generic;

namespace TicketApp.Data;

public partial class Line
{
    public int LineId { get; set; }

    public string DeparturePlace { get; set; } = null!;

    public string ArrivalPlace { get; set; } = null!;

    public int Distance { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsReservedSeated { get; set; }

    public bool IsSupplementTicketNeeded { get; set; }

    public int Price { get; set; }

    public int? NumberOfCarriages { get; set; }

    public int? NumberOfSeats { get; set; }

    public virtual ICollection<Departuretime> Departuretimes { get; } = new List<Departuretime>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
