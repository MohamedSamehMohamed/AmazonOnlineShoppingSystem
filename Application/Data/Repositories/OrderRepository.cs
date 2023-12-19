using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

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
        return _context.Orders.Include(order=>order.CartItems).ToList();
    }

    public IList<Order> GetOrderByUser(string userId)
    {
        return _context.Orders.Include(order=>order.CartItems).
            Where(order => order.UserId.Equals(userId)).ToList();
    }

    public Order? GetOrder(string orderId)
    {
        return _context.Orders.Include(order=>order.CartItems).FirstOrDefault(order => order.OrderId.Equals(orderId));
    }

    public async Task<bool> AddOrder(Order order)
    {
        try
        {
            await _context.Orders.AddAsync(order);
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
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