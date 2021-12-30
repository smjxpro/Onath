using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Data;
using Onath.Web.Models;

namespace Onath.Web.Pages;

public class Index : PageModel
{
    private readonly ApplicationDbContext _context;

    public Index(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Music> Musics { get; set; }
    public IEnumerable<App> Apps { get; set; }
    public IEnumerable<Game> Games { get; set; }
    public IEnumerable<Wallpaper> Wallpapers { get; set; }
    
    public async Task OnGetAsync()
    {
        Musics = await _context.Music.Take(3).ToListAsync();
        Apps = await _context.App.Take(3).ToListAsync();
        Games = await _context.Game.Take(3).ToListAsync();
        Wallpapers = await _context.Wallpaper.Take(3).ToListAsync();
    }
}