using TicketApp.Data;

namespace TicketApp.Models
{
    public class SearchViewModel
    {
        public LineSearchViewModel LineSearchModel { get; set; }
        public TicketappContext TicketappContext { get; set; }
        public SearchViewModel() { }

        public SearchViewModel(TicketappContext TicketappContext)
        {
            LineSearchModel = new LineSearchViewModel
            {
                DepartureTime = DateTime.Now
            };
            this.TicketappContext = TicketappContext ;
        }
    }
}
