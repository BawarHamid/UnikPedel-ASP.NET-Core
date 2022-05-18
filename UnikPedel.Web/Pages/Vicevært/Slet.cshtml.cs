using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Web.Pages.Vicevært
{
    public class SletModel : PageModel
    {
        private readonly IViceværtService _viceværtService;

        public SletModel(IViceværtService viceværtService)
        {
            _viceværtService = viceværtService;
        }

        [FromRoute] public int Id { get; set; }
        [BindProperty] public ViceværtDeleteModel Vicevært { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound(/*"Viceværten med " + Id + " eksisterer ikke.."*/);

            var domainVicevært = await _viceværtService.GetViceværtAsync(Id.Value);
            if (domainVicevært == null) return NotFound(/*"Viceværten eksisterer ikke.."*/);

            Vicevært = ViceværtDeleteModel.CreateFromViceværtDto(domainVicevært);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if (Id == null) return NotFound();

            await _viceværtService.DeleteViceværtAsync(Id.Value);

            return RedirectToPage("/Admin/Medarbejder");
        }

        public class ViceværtDeleteModel
        {
            private ViceværtDeleteModel(ViceværtDto vicevært)
            {
                Id = vicevært.Id;
                ForNavn = vicevært.ForNavn;
                EfterNavn = vicevært.EfterNavn;
                Telefon = vicevært.Telefon;
                Email = vicevært.Email;
            }

            public ViceværtDeleteModel()
            {
            }

            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }

            public ViceværtDto GetAsViceværtDto()
            {
                return new ViceværtDto 
                { 
                    Id = Id,
                    ForNavn = ForNavn,
                    EfterNavn = EfterNavn,
                    Telefon = Telefon,
                    Email = Email
                };
            }

            public static ViceværtDeleteModel CreateFromViceværtDto(ViceværtDto vicevært)
            {
                return new ViceværtDeleteModel(vicevært);
            }
        }
    }
}
