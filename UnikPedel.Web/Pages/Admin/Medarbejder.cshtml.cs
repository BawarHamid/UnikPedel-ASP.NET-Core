using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Web.Pages.Admin
{
    public class MedarbejderModel : PageModel
    {
        private readonly IViceværtService _viceværtService;

        public MedarbejderModel(IViceværtService viceværtService)
        {
            _viceværtService = viceværtService;
        }

        [BindProperty] public IEnumerable<MedarbejderGetAllModel> Viceværter { get; set; } = Enumerable.Empty<MedarbejderGetAllModel>();

        public async Task OnGetAsync()
        {
            var viceværter = new List<MedarbejderGetAllModel>();
            var dbViceværter = await _viceværtService.GetViceværterAsync();
            dbViceværter.ToList().ForEach(v => viceværter.Add(new MedarbejderGetAllModel(v)));
            Viceværter = viceværter;
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
