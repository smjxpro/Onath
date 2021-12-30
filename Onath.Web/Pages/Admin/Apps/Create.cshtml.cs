#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onath.Web.Data;
using Onath.Web.Models;
using Onath.Web.Services;
using Onath.Web.ViewModels;

namespace Onath.Web.Pages.Admin.Apps
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
        public CreateAppVM CreateAppVM { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var app = new App
            {
                Title = CreateAppVM.Title,
                Description = CreateAppVM.Description,
                 Category = CreateAppVM.Category,
            };

            app.CoverUrl = _fileService.Upload(CreateAppVM.CoverPhoto, "apps");
            app.Url = _fileService.Upload(CreateAppVM.File, "apps");
            
            _context.App.Add(app);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
