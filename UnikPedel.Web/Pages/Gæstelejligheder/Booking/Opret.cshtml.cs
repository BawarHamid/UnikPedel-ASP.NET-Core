using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Application.BookingContract.BookingDto;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Web.Pages.Gæstelejligheder.Booking
{
    public class OpretModel : PageModel
    {
        private readonly IServiceBooking _serviceBooking;

        public OpretModel(IServiceBooking serviceBooking)
        {
            _serviceBooking = serviceBooking;
        }

        [BindProperty]
        public BookingOpretModel Booking { get; set; } = new();
        public void OnGet()
        {
            Booking = new BookingOpretModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _serviceBooking.CreateAsync(Booking.GetAsBookingDto());
            return RedirectToPage("/Index");
        }
    }

    public class BookingOpretModel
    {
        public DateTime StartTid{ get; set; }
        public DateTime SlutTid{ get; set; }
        public int LejerId { get; set; }

        public int LejemaalId { get; set; }

        public BookingCreateDto GetAsBookingDto()
        {
            return new BookingCreateDto
            {
                StartTid = StartTid,
                SlutTid = SlutTid,
                LejerId = LejerId,
                LejemaalId = LejemaalId
            };
        }
    }
}
