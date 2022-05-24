using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Web.Pages.Vicevært
{
    public class EditModel : PageModel
    {
        private readonly IViceværtService _viceværtService;

        public EditModel(IViceværtService viceværtService)
        {
            _viceværtService = viceværtService;
        }

        [FromRoute] public int Id { get; set; }
        [BindProperty] public ViceværtEditModel Vicevært { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound();

            var domainVicevært = await _viceværtService.GetViceværtAsync(Id.Value);
            if (domainVicevært == null) return NotFound();

            Vicevært = ViceværtEditModel.CreateFromViceværtDto(domainVicevært);

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _viceværtService.EditViceværtAsync(Vicevært.GetAsViceværtDto());

            return RedirectToPage("/Admin/Medarbejder");
        }

        public class ViceværtEditModel
        {
            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }
            private ViceværtEditModel(ViceværtDto vicevært)
            {
                Id = vicevært.Id;
                ForNavn = vicevært.ForNavn;
                EfterNavn = vicevært.EfterNavn;
                Telefon = vicevært.Telefon;
                Email = vicevært.Email;
            }

            public ViceværtEditModel()
            {
            }

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

            public static ViceværtEditModel CreateFromViceværtDto(ViceværtDto vicevært)
            {
                return new ViceværtEditModel(vicevært);
            }
        }
    }
}
