using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockUnitOfwork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; } 
        = new MockProductRepository();
    public ICategoryRepository CategoryRepository { get; } 
        = new MockCategoryRepository();

    public IOrderRepository OrderRepository { get; }
        = new MockOrderRepository();

    public async Task SaveChangeAsync()
    {
        Console.WriteLine("save in UOW");
    }
}