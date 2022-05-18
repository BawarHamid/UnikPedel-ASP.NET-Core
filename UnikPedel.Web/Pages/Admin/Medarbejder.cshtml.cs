using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceVicev�rt;
using UnikPedel.Contract.Vicev�rtDtos;

namespace UnikPedel.Web.Pages.Admin
{
    public class MedarbejderModel : PageModel
    {
        private readonly IVicev�rtService _vicev�rtService;

        public MedarbejderModel(IVicev�rtService vicev�rtService)
        {
            _vicev�rtService = vicev�rtService;
        }

        [BindProperty] public IEnumerable<MedarbejderGetAllModel> Vicev�rter { get; set; } = Enumerable.Empty<MedarbejderGetAllModel>();

        public async Task OnGetAsync()
        {
            var vicev�rter = new List<MedarbejderGetAllModel>();
            var dbVicev�rter = await _vicev�rtService.GetVicev�rterAsync();
            dbVicev�rter.ToList().ForEach(v => vicev�rter.Add(new MedarbejderGetAllModel(v)));
            Vicev�rter = vicev�rter;
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
