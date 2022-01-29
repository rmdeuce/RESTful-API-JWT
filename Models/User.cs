using System.ComponentModel.DataAnnotations;

namespace ReastApiJwt.Models;

public class User
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}