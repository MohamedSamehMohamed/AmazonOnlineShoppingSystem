using Domain.Products;
using Domain.Users;

namespace Application.Data.MockRepositories;

public class MockAuthenticatedUser: IAuthenticatedUser
{
    private List<User> _users = new();
    public async Task<bool> UpdateUser(User user)
    {
        return true;
    }

    public List<User> GetUsers()
    {
        return _users;
    }

    public async Task<string> GetUserIdByAuthenticationId(string authenticationId)
    {
        var user = _users.FirstOrDefault(user => user.AuthenticationId.Equals(authenticationId));
        if (user == null)
            return "";
        return user.UserId;
    }

    public async Task<User?> GetAsync(string userId)
    {
        return _users.FirstOrDefault(user => user.UserId == userId);
    }

    public async Task<bool> AddAsync(User user)
    {
        _users.Add(user);
        return true;
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        var user = await GetAsync(userId);
        if (user == null) return false;
        _users.Remove(user);
        return true;
    }
}