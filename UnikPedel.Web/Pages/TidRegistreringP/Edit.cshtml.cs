using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;

namespace UnikPedel.Web.Pages.TidRegistreringP
{
    public class EditModel : PageModel
    {
        private readonly IServiceTidRegistrering _registreringService;
        public EditModel(IServiceTidRegistrering registreringService)
        {
            _registreringService = registreringService;
        }

        [FromRoute] public int Id { get; set; }
        [BindProperty] public TidRegsitreringEditModel TidRegistrering { get; set; } = new ();


        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound();
            var DtoTidreg = await _registreringService.GetTidRegistreringAsync(Id.Value);
            if (DtoTidreg == null) return NotFound();
            TidRegistrering = TidRegsitreringEditModel.CreateFromTidRegistreringDto(DtoTidreg);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _registreringService.EditTidRegistreringAsync(TidRegistrering.GetAsTidRegistreringDto());
            return RedirectToPage("./Index");
        }
    }
    public class TidRegsitreringEditModel
    {
        private TidRegsitreringEditModel(TidRegistreringDto tidRegistrering)
        {
            Id = tidRegistrering.Id;
            RegistreringDato = tidRegistrering.RegisterDato;
            AntalTimer = tidRegistrering.AntalTimer;
            viceværtID = tidRegistrering.ViceværtId;
            rekvisitionId = tidRegistrering.RekvisitionId;
        }
        public TidRegsitreringEditModel()
        {

        }
        public int Id { get; set; }
        [DisplayName("Antal Timer ")] public double AntalTimer { get; set; }

        [DisplayName("Vicevært Id")] public int viceværtID { get; set; }
        [DisplayName("Rekvisition Id")] public int rekvisitionId { get; set; }
        [DisplayName("Registrering Dato")] public DateTime RegistreringDato { get; set; } = DateTime.Now;

        public TidRegistreringDto GetAsTidRegistreringDto()
        {
            return new TidRegistreringDto
            {
                Id = Id,
                AntalTimer = AntalTimer,
                RegisterDato = RegistreringDato,
                ViceværtId = viceværtID,
                RekvisitionId = rekvisitionId
            };
        }


        public static TidRegsitreringEditModel CreateFromTidRegistreringDto(TidRegistreringDto tidRegistrering)
        {
            return new TidRegsitreringEditModel(tidRegistrering);
        }
    }
}