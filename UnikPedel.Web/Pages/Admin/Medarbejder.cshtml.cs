using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using UnikPedel.Contract.IServiceVicev�rt;
using UnikPedel.Contract.Vicev�rtDtos;
using UnikPedel.Web.Policies;

namespace UnikPedel.Web.Pages.Admin
{
    public class MedarbejderModel : PageModel
    {
        private readonly IVicev�rtService _vicev�rtService;
        private readonly IAuthorizationService _authService;
        public MedarbejderModel(IVicev�rtService vicev�rtService, IAuthorizationService authService)
        {
            _vicev�rtService = vicev�rtService;
            _authService = authService; 
        }

        [BindProperty] public IEnumerable<MedarbejderGetAllModel> Vicev�rter { get; set; } = Enumerable.Empty<MedarbejderGetAllModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            // for at hent og see alle vicev�rter, s� skal useren opfyld AdminOnly policy
            var authResult = await _authService.AuthorizeAsync(User, PolicyEnum.AdminOnly);
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }
            if (!ModelState.IsValid) return Page();
            try
            {
                var vicev�rter = new List<MedarbejderGetAllModel>();
                var dbVicev�rter = await _vicev�rtService.GetVicev�rterAsync();
                dbVicev�rter.ToList().ForEach(v => vicev�rter.Add(new MedarbejderGetAllModel(v)));
                Vicev�rter = vicev�rter;
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
            public MedarbejderGetAllModel(Vicev�rtDto vicev�rt)
            {
                Id = vicev�rt.Id;
                ForNavn = vicev�rt.ForNavn;
                EfterNavn = vicev�rt.EfterNavn;
                Telefon = vicev�rt.Telefon;
                Email = vicev�rt.Email;
            }

            public int Id { get; set; }
            public string ForNavn { get; set; }
            public string EfterNavn { get; set; }
            public int Telefon { get; set; }
            public string Email { get; set; }
        }
    }
}
