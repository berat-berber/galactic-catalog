namespace Backend;

public interface IUsersRepository
{
    Task<User> CreateUserAsync(User user);
    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User?> GetUserByIdAsync(Guid id);

    Task<User?> GetUserByEmailAsync(string email);

    Task<User> UpdateUserAsync(User user);

    Task DeleteUserAsync(User user);
}
