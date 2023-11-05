using Domain.Products;
using Application;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Category?> Get(string categoryId)
    {
        throw new NotImplementedException();
        //return  await _context.Categories.FirstOrDefaultAsync(category=>category.Id.ToString()==categoryId);
    }
}