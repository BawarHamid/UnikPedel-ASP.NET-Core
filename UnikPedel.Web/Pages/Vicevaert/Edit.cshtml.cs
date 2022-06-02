using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceVicevaert;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Web.Pages.Vicevaert
{
    public class EditModel : PageModel
    {
        private readonly IVicevaertService _vicevaertService;

        public EditModel(IVicevaertService vicevaertService)
        {
            _vicevaertService = vicevaertService;
        }

        [FromRoute] public int Id { get; set; }
        [BindProperty] public VicevaertEditModel Vicevaert { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound();

            var domainVicevaert = await _vicevaertService.GetVicevaertAsync(Id.Value);
            if (domainVicevaert == null) return NotFound();

            Vicevaert = VicevaertEditModel.CreateFromVicevaertDto(domainVicevaert);

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _vicevaertService.EditVicevaertAsync(Vicevaert.GetAsVicevaertDto());

            return RedirectToPage("/Admin/Medarbejder");
        }

        public class VicevaertEditModel
        {
            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }
            private VicevaertEditModel(VicevaertDto vicevaert)
            {
                Id = vicevaert.Id;
                ForNavn = vicevaert.ForNavn;
                EfterNavn = vicevaert.EfterNavn;
                Telefon = vicevaert.Telefon;
                Email = vicevaert.Email;
            }

            public VicevaertEditModel()
            {
            }

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

            public static VicevaertEditModel CreateFromVicevaertDto(VicevaertDto vicevaert)
            {
                return new VicevaertEditModel(vicevaert);
            }
        }
    }
}
