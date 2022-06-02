using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;

namespace UnikPedel.Web.Pages.TidRegistreringP
{
    public class IndexModel : PageModel
    {
        private readonly IServiceTidRegistrering _registreringService;
        public IndexModel(IServiceTidRegistrering registreringService)
        {
            _registreringService = registreringService;
        }
        [BindProperty]public IEnumerable<TidRegistreringIndexModel> Registreringer { get; set; }=Enumerable.Empty<TidRegistreringIndexModel>(); 
        public async Task OnGet()
        {
            var registrering = new List<TidRegistreringIndexModel>();
            var dbRegistreringer = await _registreringService.GetTidRegistreringAsync();
            dbRegistreringer.ToList().ForEach(a => registrering.Add(new TidRegistreringIndexModel(a)));
            Registreringer = registrering;
        }
    }
    public class TidRegistreringIndexModel
    {
        public int Id { get; set; }
        [DisplayName("Registrering Dato")] public DateTime RegistreringDato { get; set; } = DateTime.Now;
        [DisplayName("Antal Timer")] public double AntalTimer { get; set; }

        [DisplayName("Vicevært Id")] public int vicevaertID { get; set; }
        [DisplayName("Rekvisition Id")] public int rekvisitionId { get; set; }
      public TidRegistreringIndexModel(TidRegistreringDto registrering)
        {
            Id = registrering.Id;
            RegistreringDato = registrering.RegisterDato;
            AntalTimer = registrering.AntalTimer;
            vicevaertID = registrering.VicevaertId;
            rekvisitionId = registrering.RekvisitionId;
        }

    }
}
