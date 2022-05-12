using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

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
            public string Type { get; set; }
            public string Beskrivelse { get; set; }
            public DateTime TimeCreated { get; set; } = DateTime.Now + TimeSpan.FromMinutes(30);
            public string Status { get; set; }

            public RekvisitionDto GetAsRekvisitionDto()
            {
                return new RekvisitionDto { Type = Type, Beskrivelse = Beskrivelse, TimeCreated = TimeCreated, Status = Status };
            }
        }
    }
}
