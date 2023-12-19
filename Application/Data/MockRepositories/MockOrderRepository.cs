using Domain.Orders;
using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockOrderRepository: IOrderRepository
{
    public IList<Order> GetOrders()
    {
        return new List<Order>();
    }

    public IList<Order> GetOrderByUser(string userId)
    {
        throw new NotImplementedException();
    }

    public Order? GetOrder(string orderId)
    {
        return new Order();
    }

    public Task<bool> AddOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public bool RemoveOrder(string orderId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }
}