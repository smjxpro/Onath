#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Data;
using Onath.Web.Models;

namespace Onath.Web.Pages.Admin.Wallpapers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Onath.Web.Data.ApplicationDbContext _context;

        public EditModel(Onath.Web.Data.ApplicationDbContext context)
        {
            _context = context;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wallpaper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WallpaperExists(Wallpaper.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WallpaperExists(Guid id)
        {
            return _context.Wallpaper.Any(e => e.Id == id);
        }
    }
}
