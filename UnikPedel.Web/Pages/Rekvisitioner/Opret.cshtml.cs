using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Web.Pages.Rekvisitioner
{
    public class OpretModel : PageModel
    {
        private readonly IServiceRekvisition _serviceRekvisition;

        public OpretModel(IServiceRekvisition serviceRekvisition)
        {
            _serviceRekvisition = serviceRekvisition;   
        }

        [BindProperty] public RekvisitionOpretModel Rekvisition { get; set; } = new();


        public void OnGet()
        {
            Rekvisition = new RekvisitionOpretModel();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _serviceRekvisition.CreateRekvisitionAsync(Rekvisition.GetAsRekvisitionDto());
            return RedirectToPage("/Vicevært/RekvisitionerViceVært"); // skal rettes
        }


        public class RekvisitionOpretModel
        {
            public string Type { get; set; }
            public DateTime TimeCreated { get; set; }
            public string Status { get; set; }
            public string Beskrivelse { get; set; }
            public int ViceværtId { get; set; }
            public int LejerId { get; set; }
            public int EjendomId { get; set; }

            public RekvisitionCreateDto GetAsRekvisitionDto()
            {
                return new RekvisitionCreateDto
                {
                    Type = Type,
                    Status = Status,
                    Beskrivelse = Beskrivelse,
                    ViceværtId = ViceværtId,
                    LejerId = LejerId,
                    EjendomId = EjendomId,
                };
            }
        }



















    }
}
