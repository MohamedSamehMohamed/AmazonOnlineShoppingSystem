using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockProductRepository: IProductRepository
{
    private List<Product> _products = new List<Product>();
    public async Task<bool> UpdateProduct(Product product)
    {
        return true;
    }

    public async Task<List<Product>> GetProducts()
    {
        return _products;
    }

    public async Task<Product?> GetAsync(string productId)
    {
        return _products.FirstOrDefault(product => product.ProductId.ToString() == productId);
    }

    public async Task<bool> AddAsync(Product product)
    {
        _products.Add(product);
        return true;
    }

    public async Task<bool> DeleteAsync(string productId)
    {
        var product = await GetAsync(productId);
        if (product != null)
            _products.Remove(product);
        return true;
    }
}