using Domain.Products;

namespace Application.Data.Repositories;

public class ProductRepositoryMock: IProductRepository
{
    private readonly List<Product> _products;

    public ProductRepositoryMock()
    {
        _products = new List<Product>();
        _products.Add(new Product(
            "apple", 
            "red apple", 
            "none", 
            12.5, 
            19,
            new Category(1))
        );
        _products[0].Id = 1;
    }
    public void Add(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }
}