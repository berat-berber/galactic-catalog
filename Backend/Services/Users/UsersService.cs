using Microsoft.AspNetCore.Identity;

namespace Backend;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository) => _usersRepository = usersRepository;

    public async Task<User> CreateUserAsync(UserDTO userDTO)
    {
        var user = new User();

        user.Username = userDTO.Username;
        user.Email = userDTO.Email;
        user.HashedPassword = new PasswordHasher<User>().HashPassword(user, userDTO.RawPassword);
        user.Role = "admin";

        return await _usersRepository.CreateUserAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _usersRepository.GetAllUsersAsync();

        return users;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var user = await _usersRepository.GetUserByIdAsync(id);

        return user;
    }

    public async Task<User?> UpdateUserAsync(Guid id, UserDTO userDTO)
    {
        var user = await _usersRepository.GetUserByIdAsync(id);

        if (user is null) return user;

        user.Username = userDTO.Username;
        user.Email = userDTO.Email;
        user.HashedPassword = new PasswordHasher<User>().HashPassword(user, userDTO.RawPassword);

        await _usersRepository.UpdateUserAsync(user);

        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _usersRepository.GetUserByIdAsync(id);

        if (user is null) return false;

        await _usersRepository.DeleteUserAsync(user);

        return true;
    }
}
