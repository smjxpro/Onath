using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Onath.Web.Models;
using Onath.Web.ViewModels;

namespace Onath.Web.Pages.Account;

public class Register : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<Register> _logger;

    public Register(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
        ILogger<Register> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }

    [BindProperty] public RegisterVM RegisterVm { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");
        // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
        //     .ToList();
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = RegisterVm.Email, Email = RegisterVm.Email, FirstName = RegisterVm.FirstName,
                LastName = RegisterVm.LastName
            };
            var result = await _userManager.CreateAsync(user, RegisterVm.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                // var callbackUrl = Url.Page(
                //     "/Account/ConfirmEmail",
                //     pageHandler: null,
                //     values: new {area = "Identity", userId = user.Id, code = code},
                //     protocol: Request.Scheme);

                // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToPage("RegisterConfirmation",
                        new {email = RegisterVm.Email});
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }
}