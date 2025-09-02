namespace Backend;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


[Table("users")]
public class User
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("username")]
    public string Username { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("hashed_password")]
    public string HashedPassword { get; set; }

    [Column("role")]
    public string Role { get; set; }
}
