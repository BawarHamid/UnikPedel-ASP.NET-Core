using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Web.Pages.Vicevært
{
    public class OpretModel : PageModel
    {
        private readonly IViceværtService _viceværtService;

        public OpretModel(IViceværtService viceværtService)
        {
            _viceværtService = viceværtService;
        }

        [BindProperty] public ViceværtOpretModel Vicevært { get; set; } = new();

        public void OnGet()
        {
            Vicevært = new ViceværtOpretModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _viceværtService.CreateViceværtAsync(Vicevært.GetAsVicværtDto());
            return RedirectToPage("/Admin/Medarbejder");
        }

        public class ViceværtOpretModel
        {
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }

            public ViceværtCreateCommandDto GetAsVicværtDto()
            {
                return new ViceværtCreateCommandDto
                {
                    ForNavn = ForNavn, EfterNavn = EfterNavn, Telefon = Telefon, Email = Email
                };
            }
        }
    }
}
