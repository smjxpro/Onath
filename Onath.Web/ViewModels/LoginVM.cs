using System.ComponentModel.DataAnnotations;

namespace Onath.Web.ViewModels;

public class LoginVM
{
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}