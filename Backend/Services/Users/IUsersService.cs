namespace Backend;

public interface IUsersService
{
    Task<User> CreateUserAsync(UserDTO userDTO);
    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User?> GetUserByIdAsync(Guid id);

    Task<User?> UpdateUserAsync(Guid id, UserDTO userDTO);

    Task<bool> DeleteUserAsync(Guid id);
    
}
