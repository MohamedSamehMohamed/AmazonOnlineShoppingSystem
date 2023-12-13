using Domain.Users;

namespace Domain.Products;

public interface IAuthenticatedUser
{
    Task<bool> UpdateUser(User user);
    List<User> GetUsers();
    Task<string> GetUserIdByAuthenticationId(string authenticationId);
    Task<User?> GetAsync(string userId);
    Task<bool> AddAsync(User user);
    Task<bool> DeleteAsync(string userId);
}