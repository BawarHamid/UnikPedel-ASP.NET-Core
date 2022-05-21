using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UnikPedel.Contract.IServiceEjendomAnsvarlig;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;

namespace UnikPedel.Web.Pages.Afdelinger
{
    public class IndexModel : PageModel
    {
        private readonly IServiceEjendomAnsvarlig _serviceEjendomAnsvarlig;

        public IndexModel(IServiceEjendomAnsvarlig serviceEjendomAnsvarlig)
        {
            _serviceEjendomAnsvarlig = serviceEjendomAnsvarlig;
        }

        [BindProperty]
        public IEnumerable<EjendomAnsvarligGetAll> EjendomAnsvarlig { get; set; } = Enumerable.Empty<EjendomAnsvarligGetAll>();
        public async Task OnGetAsync()
        {
            var ejenAnsvarlig = new List<EjendomAnsvarligGetAll>();
            var dbEjenAnsvarlig = await _serviceEjendomAnsvarlig.GetEjendomAnsvarligAsync();
            dbEjenAnsvarlig.ToList().ForEach(x => ejenAnsvarlig.Add(new EjendomAnsvarligGetAll(x)));
            EjendomAnsvarlig = ejenAnsvarlig;
        }

        public class EjendomAnsvarligGetAll
        {
            public int Id { get; set; }
            public int ViceværtId { get; set; }
            public int EjendomId { get; set; }
            public EjendomAnsvarligGetAll(EjendomAnsvarligDto ejendomAnsvarlig)
            {
                Id = ejendomAnsvarlig.Id;
                ViceværtId = ejendomAnsvarlig.ViceværtId;
                EjendomId = ejendomAnsvarlig.EjendomId;

            }
        }
    }
}
