using Domain.Orders;

namespace Domain.Products;

public interface IOrderRepository
{
    IList<Order> GetOrders();
    IList<Order> GetOrderByUser(string userId);
    Order? GetOrder(string orderId);
    bool AddOrder(Order order);
    bool RemoveOrder(string orderId);
    bool UpdateOrder(Order order);
}