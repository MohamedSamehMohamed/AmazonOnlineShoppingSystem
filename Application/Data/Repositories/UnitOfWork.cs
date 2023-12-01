using Domain.Products;

namespace Application.Data.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationContext _context;
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IOrderRepository OrderRepository { get; }

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        OrderRepository = new OrderRepository(_context);
    }
    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}