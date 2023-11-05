using Domain.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class ApplicationContext: IdentityDbContext 
{
    public ApplicationContext(DbContextOptions options): base(options)
    {
        
    }
    //public DbSet<Product> Products { get; set; }
    //public DbSet<Category> Categories { get; set; }
}