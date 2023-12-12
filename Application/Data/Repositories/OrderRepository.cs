using Domain.Orders;
using Domain.Products;

namespace Application.Data.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }
    public IList<Order> GetOrders()
    {
        return _context.Orders.ToList();
    }

    public IList<Order> GetOrderByUser(string userId)
    {
        return _context.Orders.Where(order => order.UserId.Equals(userId)).ToList();
    }

    public Order? GetOrder(string orderId)
    {
        return _context.Orders.FirstOrDefault(order => order.OrderId.Equals(orderId));
    }

    public bool AddOrder(Order order)
    {
        _context.Orders.Add(order);
        return true;
    }

    public bool RemoveOrder(string orderId)
    {
        var order = GetOrder(orderId);
        if (order == null) return false;
        _context.Orders.Remove(order);
        return true;
    }

    public bool UpdateOrder(Order order)
    {
        if (GetOrder(order.OrderId) == null) 
            return false;
        _context.Orders.Update(order);
        return true;
    }
}