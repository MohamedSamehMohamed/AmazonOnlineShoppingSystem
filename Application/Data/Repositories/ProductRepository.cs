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

    public async Task<bool> UpdateProduct(Product product)
    {
        var oldProduct = await GetAsync(product.ProductId);
        if (oldProduct == null) return false;
        oldProduct.AvailableItemCount = product.AvailableItemCount;
        oldProduct.Description = product.Description;
        oldProduct.CategoryId = product.CategoryId;
        oldProduct.ImageUrl = product.ImageUrl;
        oldProduct.Name = product.Name;
        oldProduct.Price = product.Price;
        return true;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public async Task<Product?> GetAsync(string productId)
    {
        return await _context.Products.
            FirstOrDefaultAsync(product => product.ProductId.Equals(productId));
    }
    public async Task<bool> AddAsync(Product product)
    {
        try
        {
            await _context.Products.AddAsync(product);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> DeleteAsync(string productId)
    {
        var product = await GetAsync(productId);
        if (product == null) return false;
        _context.Products.Remove(product);
        return true;
    }
}