using Domain.Orders;
using Domain.Products;
using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class ApplicationContext: IdentityDbContext 
{
    public ApplicationContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> AuthenticatedUsers { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Discount> Discounts { get; set; }
}