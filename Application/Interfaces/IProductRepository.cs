namespace Domain.Products;

public interface IProductRepository
{
    Task<bool> UpdateProduct(Product product);
    Task<List<Product>> GetProducts();
    Task<Product?> GetAsync(string productId);
    Task AddAsync(Product product);
    Task<bool> DeleteAsync(string productId);
}