using Domain.Products;

namespace Application.Data;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get;}
    public ICategoryRepository CategoryRepository { get;}
    public IOrderRepository OrderRepository { get; }
    public IAuthenticatedUser AuthenticatedUser { get; }
    public IDiscount DiscountRepository { get; }
    Task SaveChangeAsync();
}