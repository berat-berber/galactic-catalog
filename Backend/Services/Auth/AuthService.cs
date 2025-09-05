
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Backend;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUsersRepository usersRepository, IConfiguration configuration) {
        _usersRepository = usersRepository;
        _configuration = configuration;
    }

    public async Task<string?> Login(LoginDTO loginDTO)
    {
        var user = await _usersRepository.GetUserByEmailAsync(loginDTO.Email);

        if (user is null) return null;

        if (new PasswordHasher<User>().VerifyHashedPassword(
            user, user.HashedPassword, loginDTO.RawPassword) == PasswordVerificationResult.Success)
        {
            return CreateToken(user);
        }
        else
        {
            return null;
        }
    }

    public async Task<User> Register(RegisterDTO registerDTO)
    {
        var user = new User();

        user.Username = registerDTO.Username;
        user.Email = registerDTO.Email;
        user.HashedPassword = new PasswordHasher<User>().HashPassword(user, registerDTO.RawPassword);
        user.Role = "user";

        await _usersRepository.CreateUserAsync(user);

        return user;
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTSettings:Token")!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenConfig = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("JWTSettings:Issuer"),
            audience: _configuration.GetValue<string>("JWTSettings:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenConfig);
    }
}
