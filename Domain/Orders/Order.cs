using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Orders;

[PrimaryKey(nameof(UserId), nameof(OrderId))]
public class Order
{
    public string UserId { get; set; }
    public string OrderId { get; set; }
    public List<CartItem> CartItems { get; set; }
    public Decimal TotalPrice { get; set; }
    public DateTime TimeOfOrder { get; set; }
}
[PrimaryKey(nameof(UserId), nameof(OrderId), nameof(ProductId))]
public record CartItem(string UserId, string OrderId, string ProductId, int Quantity, double Discount);
