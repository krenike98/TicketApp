using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TicketApp.Data;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TicketappContext _ticketappcontext;

        public HomeController(TicketappContext ticketappContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _ticketappcontext = ticketappContext;
        }
        public IActionResult Index()
        {
            SearchViewModel searchViewModel = new(_ticketappcontext);
            return View(searchViewModel);
        }

        [HttpPost]
        public IActionResult ShowSearchResult(SearchViewModel searchViewModel)
        {
            List<Departuretime> searchResults;
            string departurePlace = searchViewModel.LineSearchModel.DeparturePlace;
            DateTime? departureTime = searchViewModel.LineSearchModel.DepartureTime;
            string arrivalPlace = searchViewModel.LineSearchModel.ArrivalPlace;

            try
            {
                searchResults = _ticketappcontext.Departuretimes
                    .Include(t => t.Line)
                    .Where(e =>
                        e.Line.DeparturePlace.Contains(departurePlace) &&
                        e.Departure >= departureTime.Value &&
                        e.Departure <= departureTime.Value.AddDays(1).Date &&
                        e.Line.ArrivalPlace.Contains(arrivalPlace))
                    .ToList();
                return View("SearchLines",searchResults);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Sikertelen jegyfelvétel!" + ex.Message);
            }

            SearchViewModel newSearchViewModel = new(_ticketappcontext);
            return View(newSearchViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}