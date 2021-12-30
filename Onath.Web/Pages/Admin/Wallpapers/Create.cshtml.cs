#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onath.Web.Data;
using Onath.Web.Models;
using Onath.Web.Services;
using Onath.Web.ViewModels;

namespace Onath.Web.Pages.Admin.Wallpapers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateModel(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateWallpaperVM WallpaperVM { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var wallpaper = new Wallpaper
            {
                Title = WallpaperVM.Title,
                Description = WallpaperVM.Description,
            };

            wallpaper.Url = _fileService.Upload(WallpaperVM.File, "wallpapers");
            
            _context.Wallpaper.Add(wallpaper);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
