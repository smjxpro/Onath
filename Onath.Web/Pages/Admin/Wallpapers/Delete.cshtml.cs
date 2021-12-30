#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Data;
using Onath.Web.Models;
using Onath.Web.Services;

namespace Onath.Web.Pages.Admin.Wallpapers
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteModel(ApplicationDbContext context,IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wallpaper = await _context.Wallpaper.FindAsync(id);

            if (Wallpaper != null)
            {
                _fileService.Delete(Wallpaper.Url,"wallpapers");
                _context.Wallpaper.Remove(Wallpaper);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
