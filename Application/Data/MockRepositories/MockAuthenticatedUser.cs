using Domain.Products;
using Domain.Users;

namespace Application.Data.MockRepositories;

public class MockAuthenticatedUser: IAuthenticatedUser
{
    public Task<bool> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string userId)
    {
        throw new NotImplementedException();
    }
}