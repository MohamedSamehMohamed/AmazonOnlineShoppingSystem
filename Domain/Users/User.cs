using Domain.Orders;
using Domain.Products;

namespace Domain.Users;

public class User: Common
{
    public List<Order> Orders { get; set; }
    public List<Review> Reviews;
}