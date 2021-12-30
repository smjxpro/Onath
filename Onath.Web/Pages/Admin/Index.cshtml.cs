using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Onath.Web.Pages.Admin;

[Authorize]
public class Index : PageModel
{
    public void OnGet()
    {
        
    }
}