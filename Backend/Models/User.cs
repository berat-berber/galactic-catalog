namespace Backend;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


[Table("users")]
public class User
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("hashed_password")]
    public string HashedPassword { get; set; } = null!;

    [Column("role")]
    public string Role { get; set; } = null!;
}
