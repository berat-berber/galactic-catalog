using System.ComponentModel.DataAnnotations;

namespace Backend;

public class LoginDTO
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string RawPassword { get; set; } = null!;
}
