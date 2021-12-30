#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Data;
using Onath.Web.Models;

namespace Onath.Web.Pages.Wallpapers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Wallpaper> Wallpaper { get;set; }

        public async Task OnGetAsync()
        {
            Wallpaper = await _context.Wallpaper.ToListAsync();
        }
    }
}
