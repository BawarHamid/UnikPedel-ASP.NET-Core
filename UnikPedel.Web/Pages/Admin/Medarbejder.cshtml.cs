using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using UnikPedel.Contract.IServiceVicevaert;
using UnikPedel.Contract.VicevaertDtos;
using UnikPedel.Web.Policies;

namespace UnikPedel.Web.Pages.Admin
{
    public class MedarbejderModel : PageModel
    {
        private readonly IVicevaertService _vicevaertService;
        private readonly IAuthorizationService _authService;
        public MedarbejderModel(IVicevaertService vicevaertService, IAuthorizationService authService)
        {
            _vicevaertService = vicevaertService;
            _authService = authService; 
        }

        [BindProperty] public IEnumerable<MedarbejderGetAllModel> Vicevaerter { get; set; } = Enumerable.Empty<MedarbejderGetAllModel>();

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
                var vicevaerter = new List<MedarbejderGetAllModel>();
                var dbVicevaerter = await _vicevaertService.GetVicevaerterAsync();
                dbVicevaerter.ToList().ForEach(v => vicevaerter.Add(new MedarbejderGetAllModel(v)));
                Vicevaerter = vicevaerter;
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
            public MedarbejderGetAllModel(VicevaertDto vicevaert)
            {
                Id = vicevaert.Id;
                ForNavn = vicevaert.ForNavn;
                EfterNavn = vicevaert.EfterNavn;
                Telefon = vicevaert.Telefon;
                Email = vicevaert.Email;
            }

            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }
        }
    }
}
