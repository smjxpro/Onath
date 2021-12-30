#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Models;

namespace Onath.Web.Pages.Wallpapers
{

    public class DetailsModel : PageModel
    {
        private readonly Onath.Web.Data.ApplicationDbContext _context;

        public DetailsModel(Onath.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Wallpaper Wallpaper { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wallpaper = await _context.Wallpaper.FirstOrDefaultAsync(m => m.Id == id);

            if (Wallpaper == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
