using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockUnitOfwork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; } 
        = new MockProductRepository();
    public ICategoryRepository CategoryRepository { get; } 
        = new MockCategoryRepository();

    public async Task SaveChangeAsync()
    {
        Console.WriteLine("save in UOW");
    }
}