using Microsoft.AspNetCore.Identity;

namespace Onath.Web.Models;

public class ApplicationUser:IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}