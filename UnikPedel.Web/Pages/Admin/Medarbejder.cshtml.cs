using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;
using UnikPedel.Web.Policies;

namespace UnikPedel.Web.Pages.Admin
{
    public class MedarbejderModel : PageModel
    {
        private readonly IViceværtService _viceværtService;
        private readonly IAuthorizationService _authService;
        public MedarbejderModel(IViceværtService viceværtService, IAuthorizationService authService)
        {
            _viceværtService = viceværtService;
            _authService = authService; 
        }

        [BindProperty] public IEnumerable<MedarbejderGetAllModel> Viceværter { get; set; } = Enumerable.Empty<MedarbejderGetAllModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            // for at hent og see alle viceværter, så skal useren opfyld AdminOnly policy
            var authResult = await _authService.AuthorizeAsync(User, PolicyEnum.AdminOnly);
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }
            if (!ModelState.IsValid) return Page();
            try
            {
                var viceværter = new List<MedarbejderGetAllModel>();
                var dbViceværter = await _viceværtService.GetViceværterAsync();
                dbViceværter.ToList().ForEach(v => viceværter.Add(new MedarbejderGetAllModel(v)));
                Viceværter = viceværter;
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return Page();
            }
            
            return Page();
        }

        public class MedarbejderGetAllModel
        {
            public MedarbejderGetAllModel(ViceværtDto vicevært)
            {
                Id = vicevært.Id;
                ForNavn = vicevært.ForNavn;
                EfterNavn = vicevært.EfterNavn;
                Telefon = vicevært.Telefon;
                Email = vicevært.Email;
            }

            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }
        }
    }
}
