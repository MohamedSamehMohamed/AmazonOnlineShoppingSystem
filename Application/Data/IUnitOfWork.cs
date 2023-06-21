using Domain.Products;

namespace Application.Data;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get;}
    Task SaveChangeAsync();
}