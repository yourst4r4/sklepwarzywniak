using System.ComponentModel.DataAnnotations;

namespace Warzywniak.ViewModels;

public class RegisterViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Login { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = "";

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Hasła muszą być identyczne.")]
    public string ConfirmPassword { get; set; } = "";

    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";
}