using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UnikPedel.Domain.Entities;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Web.Pages.Vicevært
{
    public class IndexModel : PageModel
    {
        private readonly UnikPedelContext _unikPedelContext;
        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }

        public IndexModel(UnikPedelContext unikPedelContext)
        {
            _unikPedelContext = unikPedelContext;
        }
        public void OnGet()
        {
            //Rekvisitioner = await _unikPedelContext.Rekvisition.ToListAsync();
        }
    }
}
