using Domain.Products;

namespace Application.Data.Repositories;

public class UnitOfWork: IUnitOfWork
{
    
    public IProductRepository ProductRepository { get; }

    public UnitOfWork()
    {
        ProductRepository = new ProductRepositoryMock();
    }
    public async Task SaveChangeAsync()
    {
        Console.WriteLine("save change");
    }
}