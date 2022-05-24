using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Web.Pages.Gæstelejligheder
{
    public class IndexModel : PageModel
    {
        private readonly IServiceBooking _serviceBooking;

        [BindProperty]
        public IEnumerable<BookingGetAll> Bookinger { get; set; } = Enumerable.Empty<BookingGetAll>();

        public IndexModel(IServiceBooking serviceBooking)
        {
            _serviceBooking = serviceBooking;
        }
        public async Task OnGetAsync()
        {
            var booking = new List<BookingGetAll>();
            var dbBooking = await _serviceBooking.GetBookingsAsync();
            dbBooking.ToList().ForEach(x => booking.Add(new BookingGetAll(x)));
            Bookinger = booking;
        }

    }

    public class BookingGetAll
    {
        public int Id { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public int LejerId { get; set; }

        public int LejemålId { get; set; }

        public BookingGetAll(BookingDto booking)
        {
            Id = booking.Id;
            StartTid = booking.StartTid;
            SlutTid = booking.SlutTid;
            LejerId = booking.LejerId;
            LejemålId = booking.LejemålId;
        }
    }
}
