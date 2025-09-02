namespace Backend;

public record class UserDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string RawPassword { get; set; }
}
