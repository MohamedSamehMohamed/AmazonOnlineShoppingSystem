using Domain.Products;

namespace Application.Data;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get;}
    public ICategoryRepository CategoryRepository { get;}
    public IOrderRepository OrderRepository { get; }
    Task SaveChangeAsync();
}