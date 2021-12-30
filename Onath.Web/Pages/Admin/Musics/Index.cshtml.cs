#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Data;

namespace Onath.Web.Pages.Admin.Musics
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Music> Music { get;set; }

        public async Task OnGetAsync()
        {
            Music = await _context.Music.ToListAsync();
        }
    }
}
