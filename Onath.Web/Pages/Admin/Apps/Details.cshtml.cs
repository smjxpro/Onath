#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Data;
using Onath.Web.Models;

namespace Onath.Web.Pages.Admin.Apps
{
    [Authorize]

    public class DetailsModel : PageModel
    {
        private readonly Onath.Web.Data.ApplicationDbContext _context;

        public DetailsModel(Onath.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public App App { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            App = await _context.App.FirstOrDefaultAsync(m => m.Id == id);

            if (App == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
