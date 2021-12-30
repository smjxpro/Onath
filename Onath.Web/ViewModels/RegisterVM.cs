using System.ComponentModel.DataAnnotations;

namespace Onath.Web.ViewModels;

public class RegisterVM
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}