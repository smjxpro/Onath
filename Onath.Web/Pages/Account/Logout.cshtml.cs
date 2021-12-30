using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onath.Web.Models;

namespace Onath.Web.Pages.Account;

public class Logout : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public Logout(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task<ActionResult> OnGetAsync()
    {
       await _signInManager.SignOutAsync();

       return RedirectToPage("/Index");
    }
}