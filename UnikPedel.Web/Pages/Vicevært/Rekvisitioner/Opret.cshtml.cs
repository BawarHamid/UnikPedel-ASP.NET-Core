using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Web.Pages.Vicevært.Rekvisitioner
{
    public class OpretModel : PageModel
    {
        private readonly IServiceRekvisition _rekvisitionService;
        public OpretModel(IServiceRekvisition rekvisitionService)
        {
            _rekvisitionService = rekvisitionService;
        }

        [BindProperty] public RekvisitionCreateModel Rekvisition { get; set; } = new();

        public void OnGet()
        {
            Rekvisition = new RekvisitionCreateModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _rekvisitionService.CreateRekvisitionAsync(Rekvisition.GetAsRekvisitionDto());
            return RedirectToPage("./Index");
        }

        public class RekvisitionCreateModel
        {
            public Guid Id { get; set; }

            public string Type { get; set; }
            public DateTime TimeCreated { get; set; }
            public string Status { get; set; }
            public string Beskrivelse { get; set; }

            public ViceværtDto Vicevært { get; set; }

            //public Lejer Lejer { get; set; }
            public EjendomDto Ejendom { get; set; }

            public RekvisitionDto GetAsRekvisitionDto()
            {
                return new RekvisitionDto { Beskrivelse = Beskrivelse, Type = Type };
            }
        }
    }
}
