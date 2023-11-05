namespace Domain.Products;

public interface IProductRepository
{
    Task<Product?> Get(string productId);
    Task<bool> AddAsync(Product product);
    Task<bool> DeleteAsync(string productId);
}