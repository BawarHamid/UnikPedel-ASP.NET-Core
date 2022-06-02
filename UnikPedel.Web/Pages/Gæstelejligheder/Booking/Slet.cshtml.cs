using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Web.Pages.Gæstelejligheder.Booking
{
    public class SletModel : PageModel
    {
        private readonly IServiceBooking _serviceBooking;

        public SletModel(IServiceBooking serviceBooking)
        {
            _serviceBooking = serviceBooking;
        }

        [FromRoute]
        public int Id { get; set; }
        [BindProperty]
        public BookingDeletModel Booking { get; set; } = new();
        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound("Booking med "+Id+" eksister ikke!");
            
            var domainBooking = await _serviceBooking.GetBookingAsync(Id.Value);
            if (domainBooking == null) return NotFound("Booking med " + Id + " eksister ikke!");
            Booking = BookingDeletModel.CreateFromBookingDto(domainBooking);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if(Id == null) return NotFound("Booking med "+Id+" eksister ikke!");
            await _serviceBooking.DeleteAsync(Id.Value);
            return RedirectToPage("/Gæstelejligheder/Index");
        }
    }

    public class BookingDeletModel
    {
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public int LejerId { get; set; }

        public int LejemaalId { get; set; }

        public BookingDeletModel()
        {

        }

        public BookingDeletModel(BookingDto booking)
        {
            StartTid = booking.StartTid;
            SlutTid = booking.SlutTid;
            LejerId = booking.LejerId;
            LejemaalId = booking.LejemaalId;
        }
        public BookingDto GetBookingDto()
        {
            return new BookingDto
            {
                StartTid = StartTid,
                SlutTid = SlutTid,
                LejerId = LejerId,
                LejemaalId = LejemaalId
            };
        }

        public static BookingDeletModel CreateFromBookingDto(BookingDto booking)
        {
            return new BookingDeletModel(booking);
        }
    }
}
