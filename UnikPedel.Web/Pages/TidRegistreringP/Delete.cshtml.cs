using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;

namespace UnikPedel.Web.Pages.TidRegistreringP
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceTidRegistrering _registreringService;
        public DeleteModel(IServiceTidRegistrering registreringService)
        {
            _registreringService = registreringService;
        }

        [FromRoute] public int Id { get; set; }
        [BindProperty] public TidRegistreringDeleteModel TidRegistrering { get; set; } = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null) return NotFound();

            var domainRegistrering = await _registreringService.GetTidRegistreringAsync(id);
            if (domainRegistrering == null) return NotFound();

            TidRegistrering = TidRegistreringDeleteModel.GetAsTidRegistreringDeletModel(domainRegistrering);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null) return NotFound();

            await _registreringService.DeleteTidRegistreringAsync(id);

            return RedirectToPage("./Index");
        }

    }

    public class TidRegistreringDeleteModel
    {
        public int Id { get; set; }
        [DisplayName("Registrering Dato")] public DateTime RegistreringDato { get; set; } = DateTime.Now;
        [DisplayName("Antal Timer")] public double AntalTimer { get; set; }

        [DisplayName("Vicev�rt Id")] public int vicev�rtID { get; set; }
        [DisplayName("Rekvisition Id")] public int rekvisitionId { get; set; }

        public TidRegistreringDeleteModel()
        {

        }

        private TidRegistreringDeleteModel(TidRegistreringDto registrering)
        {
            Id=registrering.Id;
            RegistreringDato = registrering.RegisterDato;
            AntalTimer=registrering.AntalTimer;
            vicev�rtID = registrering.Vicev�rtId;
            rekvisitionId = registrering.RekvisitionId;
        }

        public static TidRegistreringDeleteModel GetAsTidRegistreringDeletModel(TidRegistreringDto registrering)
        {
            return new TidRegistreringDeleteModel(registrering);
        }
    }
}