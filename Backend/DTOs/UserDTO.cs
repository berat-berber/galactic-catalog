namespace Backend;
using System.ComponentModel.DataAnnotations;

public record class UserDTO
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string RawPassword { get; set; } = null!;

    [Required]
    public string Role { get; set; } = null!;
}
