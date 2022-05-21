using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikPedel.Application;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Web.Pages.Admin.Kalender
{
    public class OpretModel : PageModel
    {
        private readonly IServiceRekvisition _serviceRekvisition;

        public OpretModel(IServiceRekvisition serviceRekvisition)
        {
            _serviceRekvisition = serviceRekvisition;
        }

        [BindProperty]
        public RekvisitionOpret Rekvision { get; set; } = new();
        public void OnGet()
        {
            Rekvision = new RekvisitionOpret();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _serviceRekvisition.CreateRekvisitionAsync(Rekvision.GetasRekvisitionDto());
            return RedirectToPage("/Admin/Kalender");
        } 

        public class RekvisitionOpret
        {
            public string Type { get; set; }
            public string Beskrivelse { get; set; }
            public DateTime TimeCreated { get; set; }
            public string Status { get; set; }
            
            public RekvisitionCreateDto GetasRekvisitionDto()
            {
                return new RekvisitionCreateDto()
                {
                    Type = Type,
                    Beskrivelse = Beskrivelse,
                    TimeCreated = TimeCreated,
                    Status = Status
                };
            }
        }
    }
}
