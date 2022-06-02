using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.IServiceVicevaert;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Web.Pages.Vicevaert
{
    public class OpretModel : PageModel
    {
        private readonly IVicevaertService _vicevaertService;

        public OpretModel(IVicevaertService vicevaertService)
        {
            _vicevaertService = vicevaertService;
        }

        [BindProperty] public VicevaertOpretModel Vicevaert { get; set; } = new();

        public void OnGet()
        {
            Vicevaert = new VicevaertOpretModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _vicevaertService.CreateVicevaertAsync(Vicevaert.GetAsVicværtDto());
            return RedirectToPage("/Admin/Medarbejder");
        }

        public class VicevaertOpretModel
        {
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }

            public VicevaertCreateDto GetAsVicværtDto()
            {
                return new VicevaertCreateDto
                {
                    ForNavn = ForNavn, EfterNavn = EfterNavn, Telefon = Telefon, Email = Email
                };
            }
        }
    }
}
