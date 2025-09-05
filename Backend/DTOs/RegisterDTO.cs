using System.ComponentModel.DataAnnotations;

namespace Backend;

public class RegisterDTO
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string RawPassword { get; set; } = null!;
}
