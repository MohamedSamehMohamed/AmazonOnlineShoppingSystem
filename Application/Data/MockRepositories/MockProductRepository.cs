using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockProductRepository: IProductRepository
{
    private List<Product> _products = new List<Product>();
    public async Task<Product?> Get(string productId)
    {
        return _products.FirstOrDefault(product => product.Id.ToString() == productId);
    }

    public async Task<bool> AddAsync(Product product)
    {
        _products.Add(product);
        return true;
    }

    public async Task<bool> DeleteAsync(string productId)
    {
        var product = await Get(productId);
        if (product != null)
            _products.Remove(product);
        return true;
    }
    
}