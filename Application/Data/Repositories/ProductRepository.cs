using Domain.Products;
using Application;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Product?> Get(string productId)
    {
        throw new NotImplementedException();
        //return await _context.Products.FirstOrDefaultAsync(product => product.Id.ToString() == productId);
    }

    public async Task<bool> AddAsync(Product product)
    {
        try
        {
            throw new NotImplementedException();
            //await _context.Products.AddAsync(product);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string productId)
    {
        var product = await Get(productId);
        if (product == null) return false;
        throw new NotImplementedException();
        //_context.Products.Remove(product);
        return true;
    }
}