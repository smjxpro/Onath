#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onath.Web.Data;
using Onath.Web.Services;
using Onath.Web.ViewModels;

namespace Onath.Web.Pages.Admin.Musics
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
        public CreateMusicVM Music { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var music = new Models.Music
            {
                Title = Music.Title,
                Artist = Music.Artist,
                Album = Music.Album,
            };
            music.Url = _fileService.Upload(Music.File,"musics");
            _context.Music.Add(music);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        
       
    }
}
