using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;
using UnikPedel.Contract.IServiceLejer;
using UnikPedel.Contract.IServiceLejer.LejerDtos;

namespace UnikPedel.Web.Pages.Gæstelejligheder.Booking
{
    public class IndexForLejerModel : PageModel
    {
        private readonly IServiceBookingLejer _serviceBooking;
        private readonly UserManager<IdentityUser> _userManager;
        private ILejerService _lejerService;

        [BindProperty]
        public IEnumerable<BookingIndexModel> Bookinger { get; set; } = Enumerable.Empty<BookingIndexModel>();

        public IndexForLejerModel(IServiceBookingLejer serviceBooking, UserManager<IdentityUser> userManager, ILejerService lejerService)
        {
            _serviceBooking = serviceBooking;
            _userManager = userManager;
            _lejerService = lejerService;

        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var lejreListe = await _lejerService.GetLejereAsync();
            var email = _userManager.GetUserName(User).ToString();

            var lejer = CheckListe(lejreListe, email);

            var booking = new List<BookingIndexModel>();
            var dbBooking = await _serviceBooking.GetBookingForLejerAsync(lejer.Id);
            dbBooking.ToList().ForEach(x => booking.Add(new BookingIndexModel(x)));
            Bookinger = booking;
            return Page();
        }

        public static LejerDto CheckListe(IEnumerable<LejerDto> Liste, string email)
        {
            var result = new LejerDto();
            foreach (var lejer in Liste)
            {
                if (lejer.Email == email)
                {
                    result = new LejerDto()
                    {
                        Id = lejer.Id,
                        MellemNavn = lejer.MellemNavn,
                        EfterNavn = lejer.EfterNavn,
                        Email = lejer.Email,
                        Telefon = lejer.Telefon,
                        LejemaalId = lejer.LejemaalId,
                        IndDato = lejer.IndDato,
                        UdDato = lejer.UdDato
                    };
                }
                else
                    result = null;
            }
            return result;
        }
    }


    public class BookingIndexModel
    {
        public int Id { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public int LejerId { get; set; }

        public int LejemaalId { get; set; }

        public BookingIndexModel(BookingDto booking)
        {
            Id = booking.Id;
            StartTid = booking.StartTid;
            SlutTid = booking.SlutTid;
            LejerId = booking.LejerId;
            LejemaalId = booking.LejemaalId;
        }
    }
}
