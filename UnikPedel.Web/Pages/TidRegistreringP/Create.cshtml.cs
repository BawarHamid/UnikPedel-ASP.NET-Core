using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;
using UnikPedel.Contract.Vicev�rtDtos;

namespace UnikPedel.Web.Pages.TidRegsitrering
{
    public class CreateModel : PageModel
    {
        private readonly IServiceTidRegistrering _registreringService;
        public CreateModel( IServiceTidRegistrering registreringService)
        {
            _registreringService = registreringService; 
        }
        [BindProperty] public TidRegsitreringCreateModel TidRegistrering { get; set; }
        public void OnGet()
        {
            TidRegistrering   = new TidRegsitreringCreateModel();   
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _registreringService.CreateTidRegistreringAsync(TidRegistrering.GetAsTidRegistreringCreateDto());
            return RedirectToPage("/Index");
        }
    }
    public class TidRegsitreringCreateModel
    {
        public int Id { get; set; }
       [DisplayName("Registrering Dato")] public DateTime RegistreringDato { get; set; } = DateTime.Now;
        [DisplayName("Antal Timer")]public double AntalTimer { get; set; }

        [DisplayName("Vicev�rt Id")] public int  vicev�rtID { get; set; }
        [DisplayName("Rekvisition Id")] public int rekvisitionId { get; set; }

        public TidRegistreringCreateDto GetAsTidRegistreringCreateDto()
        {
            return new TidRegistreringCreateDto {RegisterDato=RegistreringDato,AntalTimer=AntalTimer,Vicev�rtId=vicev�rtID,RekvisitionId=rekvisitionId };
        }

    }
}
