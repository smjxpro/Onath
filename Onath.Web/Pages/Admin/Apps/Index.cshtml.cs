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
    public class IndexModel : PageModel
    {
        private readonly Onath.Web.Data.ApplicationDbContext _context;

        public IndexModel(Onath.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<App> App { get;set; }

        public async Task OnGetAsync()
        {
            App = await _context.App.ToListAsync();
        }
    }
}
