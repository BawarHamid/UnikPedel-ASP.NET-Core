using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Web.Pages.Gæstelejligheder.Booking
{
    public class EditModel : PageModel
    {
        private readonly IServiceBooking _serviceBooking;

        public EditModel(IServiceBooking serviceBooking)
        {
            _serviceBooking = serviceBooking;
        }

        [FromRoute]
        public int Id { get; set; }
        [BindProperty]
        public BookingEditModel Booking { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound();
            var domainBooking = await _serviceBooking.GetBookingAsync(Id.Value);
            if(domainBooking == null) return NotFound();

            Booking = BookingEditModel.CreateFromBookingDto(domainBooking);
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _serviceBooking.EditAsync(Booking.GetAsBookingDto());
            return RedirectToPage("/Gæstelejligheder/Index");
        }
    }

    public class BookingEditModel
    {
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public int LejerId { get; set; }
        public int LejemålId { get; set; }


        public BookingEditModel(BookingDto booking)
        {
            StartTid = booking.StartTid;
            SlutTid = booking.SlutTid;
            LejerId = booking.LejerId;
            LejemålId = booking.LejemålId;
        }

        public BookingEditModel()
        {

        }

        public BookingDto GetAsBookingDto()
        {
            return new BookingDto
            {
                StartTid = StartTid,
                SlutTid = SlutTid,
                LejerId = LejerId,
                LejemålId = LejemålId
            };
        }

        public static BookingEditModel CreateFromBookingDto(BookingDto booking)
        {
            return new BookingEditModel(booking);
        }

    }
}
