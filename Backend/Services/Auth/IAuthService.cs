namespace Backend;

public interface IAuthService
{
    Task<User> Register(RegisterDTO registerDTO);

    Task<string?> Login(LoginDTO loginDTO);

}
