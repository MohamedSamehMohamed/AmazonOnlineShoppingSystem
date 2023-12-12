using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Repositories;

public class AuthenticatedUser: IAuthenticatedUser
{
    private readonly ApplicationContext _context;

    public AuthenticatedUser(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> UpdateUser(User user)
    {
        _context.AuthenticatedUsers.Update(user);
        return true;
    }

    public List<User> GetUsers()
    {
        return _context.AuthenticatedUsers.ToList();
    }

    public async Task<User?> GetAsync(string userId)
    {
        return await _context.AuthenticatedUsers.FirstOrDefaultAsync(user => user.UserId.Equals(userId));
    }

    public async Task<bool> AddAsync(User user)
    {
        _context.AuthenticatedUsers.AddAsync(user);
        return true;
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        var user = await GetAsync(userId);
        if (user == null) return false;
        _context.AuthenticatedUsers.Remove(user);
        return true;
    }
}