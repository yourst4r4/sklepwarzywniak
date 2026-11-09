using System.ComponentModel.DataAnnotations;

namespace Warzywniak.ViewModels;

public class LoginViewModel
{
    [Required]
    public string Login { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}