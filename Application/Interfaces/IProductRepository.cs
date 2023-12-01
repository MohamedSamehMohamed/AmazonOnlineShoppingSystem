namespace Domain.Products;

public interface IProductRepository
{
    Task<bool> UpdateProduct(Product product);
    List<Product> GetProducts();
    Task<Product?> GetAsync(string productId);
    Task<bool> AddAsync(Product product);
    Task<bool> DeleteAsync(string productId);
}