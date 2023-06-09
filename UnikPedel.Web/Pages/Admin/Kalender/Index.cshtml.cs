using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Web.Pages.Kalender
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRekvisition _serviceRekvisition;

        public IndexModel(IServiceRekvisition serviceRekvisition)
        {
            _serviceRekvisition = serviceRekvisition;
        }

        [BindProperty]
        public IEnumerable<RekvisitionGetAllRek> Rekvisitioner { get; set; } = Enumerable.Empty<RekvisitionGetAllRek>();

        public async Task OnGetAsync()
        {
            var rekvisitioner = new List<RekvisitionGetAllRek>();
            var DatabaseRekvi = await _serviceRekvisition.GetRekvisitionerAsync();
            DatabaseRekvi.ToList().ForEach(x => rekvisitioner.Add(new RekvisitionGetAllRek(x)));
            Rekvisitioner = rekvisitioner;
        }

        public class RekvisitionGetAllRek
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Beskrivelse { get; set; }
            public string Status  { get; set; }
            public int VicevaertId { get; set; }
            public int LejerId { get; set; }
            public int EjendomId { get; set; }

            public RekvisitionGetAllRek(RekvisitionDto rekvisition)
            {
                Id = rekvisition.Id;
                Type = rekvisition.Type;
                Beskrivelse = rekvisition.Beskrivelse;
                Status = rekvisition.Status;
                VicevaertId = rekvisition.VicevaertId;
                LejerId = rekvisition.LejerId;
                EjendomId = rekvisition.EjendomId;

            }
        }
    }
}
