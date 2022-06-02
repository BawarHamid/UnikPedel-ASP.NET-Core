using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceVicevaert;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Web.Pages.Vicevaert
{
    public class SletModel : PageModel
    {
        private readonly IVicevaertService _vicevaertService;

        public SletModel(IVicevaertService vicevaertService)
        {
            _vicevaertService = vicevaertService;
        }

        [FromRoute] public int Id { get; set; }
        [BindProperty] public VicevaertDeleteModel Vicevaert { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound("Viceværten med " + Id + " eksisterer ikke..");

            var domainVicevaert = await _vicevaertService.GetVicevaertAsync(Id.Value);
            if (domainVicevaert == null) return NotFound("Viceværten med " + Id + " eksisterer ikke..");

            Vicevaert = VicevaertDeleteModel.CreateFromVicevaertDto(domainVicevaert);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if (Id == null) return NotFound("Viceværten med " + Id + " eksisterer ikke..");

            await _vicevaertService.DeleteVicevaertAsync(Id.Value);

            return RedirectToPage("/Admin/Medarbejder");
        }

        public class VicevaertDeleteModel
        {
            private VicevaertDeleteModel(VicevaertDto vicevaert)
            {
                Id = vicevaert.Id;
                ForNavn = vicevaert.ForNavn;
                EfterNavn = vicevaert.EfterNavn;
                Telefon = vicevaert.Telefon;
                Email = vicevaert.Email;
            }

            public VicevaertDeleteModel()
            {
            }

            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }

            public VicevaertDto GetAsVicevaertDto()
            {
                return new VicevaertDto 
                { 
                    Id = Id,
                    ForNavn = ForNavn,
                    EfterNavn = EfterNavn,
                    Telefon = Telefon,
                    Email = Email
                };
            }

            public static VicevaertDeleteModel CreateFromVicevaertDto(VicevaertDto vicevaert)
            {
                return new VicevaertDeleteModel(vicevaert);
            }
        }
    }
}
