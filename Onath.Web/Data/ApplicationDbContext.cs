#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onath.Web.Models;

namespace Onath.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Music> Music { get; set; }

        public DbSet<Wallpaper> Wallpaper { get; set; }

        public DbSet<App> App { get; set; }

        public DbSet<Game> Game { get; set; }
    }
}
