using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Web.Pages.Rekvisitioner
{
    public class SletModel : PageModel
    {
        private readonly IServiceRekvisition _serviceRekvisition;

        public SletModel(IServiceRekvisition serviceRekvisition)
        {
            _serviceRekvisition = serviceRekvisition;
        }

        [FromRoute]
        public int Id { get; set; }
        [BindProperty]
        public RekvisitionDeleteModel Rekvisition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null) return NotFound("Rekvisition med "+Id+" eksister ikke!");

            var domainRek = await _serviceRekvisition.GetRekvisitionAsync(Id.Value);
            if (domainRek == null) return NotFound("Rekvisition med "+Id+" eksister ikke!");

            Rekvisition = RekvisitionDeleteModel.CreateFromRekvisitionDto(domainRek);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if (Id == null) return NotFound("Rekvisition med " + Id + " eksisterer ikke..");

            await _serviceRekvisition.DeleteRekvisitionAsync(Id.Value);

            return RedirectToPage("/Admin/Medarbejder");
        }


    }

    public class RekvisitionDeleteModel
    {
        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }
        public int ViceværtId { get; set; }
        public int LejerId { get; set; }
        public int EjendomId { get; set; }


        public RekvisitionDeleteModel(RekvisitionDto rekvisition)
        {
            Type = rekvisition.Type;
            TimeCreated = rekvisition.TimeCreated;
            Status = rekvisition.Status;
            Beskrivelse = rekvisition.Beskrivelse;
            ViceværtId = rekvisition.ViceværtId;
            LejerId = rekvisition.LejerId;
            EjendomId = rekvisition.EjendomId;
        }

        public RekvisitionDeleteModel()
        {

        }

        public RekvisitionDto GetRekvisitionDto()
        {
            return new RekvisitionDto
            {
                Type = Type,
                TimeCreated = TimeCreated,
                Status = Status,
                Beskrivelse = Beskrivelse,
                ViceværtId = ViceværtId,
                LejerId = LejerId,
                EjendomId = EjendomId,
            };
        }

        public static RekvisitionDeleteModel CreateFromRekvisitionDto(RekvisitionDto rekvisition)
        {
            return new RekvisitionDeleteModel(rekvisition);
        }
    }
}
