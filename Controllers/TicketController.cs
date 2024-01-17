using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TicketApp.Data;

namespace TicketApp.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private TicketappContext _ticketappcontext;
        public TicketController(TicketappContext ticketappContext, ILogger<TicketController> logger)
        {
            _logger = logger;
            _ticketappcontext = ticketappContext;
        }

        public IActionResult NewTicket(int departureTimeId)
        {
            Departuretime deptime;
            try
            {
                deptime = _ticketappcontext.Departuretimes
                .Where(d => d.DepartureTimeId.Equals(departureTimeId)).First();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Sikertelen jegyfelvétel!" + ex.Message);
                return View();
            }
            Ticket newTicket = new Ticket()
            {
                TicketId = Guid.NewGuid().ToString(),
                DepartureTime = deptime,
                DepartureTimeId = departureTimeId,
                LineId = deptime.LineId,
            };
            return View("NewTicket", newTicket);
        }

        [HttpPost]
        public IActionResult CreateTicket(Ticket newTicket)
        {
            try
            {
                var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                newTicket.UserId = loggedInUserId;
                _ticketappcontext.Tickets.Add(newTicket);
                _ticketappcontext.SaveChanges();
                TempData["SuccessMessage"] = "A rendelést sikeresen leadtad! Rendelési azonosító: " + newTicket.TicketId.ToString();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Sikertelen jegyfelvétel!" + ex.Message);
            }
            return View("NewTicket", newTicket);
        }

        public IActionResult ShowTicket(string TicketId)
        {
            Ticket ticket;
            try
            {
                ticket = _ticketappcontext.Tickets
                    .Include(t => t.DepartureTime)
                    .Include(t => t.Line)
                    .Where(d => d.TicketId.Equals(TicketId)).First();
                return View("ShowTicket", ticket);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Sikertelen jegyfelvétel!" + ex.Message);
            }
            return View();
        }
    }
}
