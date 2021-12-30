#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onath.Web.Data;
using Onath.Web.Models;
using Onath.Web.Services;
using Onath.Web.ViewModels;

namespace Onath.Web.Pages.Admin.Games
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
        public CreateGameVM CreateGameVM { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var game = new Game
            {
                Title = CreateGameVM.Title,
                Description = CreateGameVM.Description,
                Genre = CreateGameVM.Genre,
            };
            game.CoverUrl = _fileService.Upload(CreateGameVM.CoverPhoto, "games");
            game.Url = _fileService.Upload(CreateGameVM.File, "games");
            _context.Game.Add(game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
