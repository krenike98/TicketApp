using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TicketApp.Data;

public partial class Ticket
{
    public string TicketId { get; set; }

    public int LineId { get; set; }

    public string UserId { get; set; }

    public int DepartureTimeId { get; set; }
    public string PassengerName { get; set; } = null!;
    public string PassengerAdress { get; set; } = null!;
    public string PassengerEmail { get; set; } = null!;
    public string PassengerPhoneNumber { get; set; } = null!;

    public virtual Departuretime DepartureTime { get; set; } = null!;

    public virtual Line Line { get; set; } = null!;

    public virtual IdentityUser User { get; set; } = null!;
}
