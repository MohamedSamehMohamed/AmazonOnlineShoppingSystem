using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Orders;

public enum OrderStatus
{
    InProcess,
    InShipping,
    Delivered
}

public enum PaymentMethod
{
    CreditCard,
    ElectronicBank,
    CashOnDelivery
}
[PrimaryKey(nameof(OrderId))]
public class Order
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; }
    public List<CartItem> CartItems { get; set; } = new();
    public Decimal TotalPrice
    {
        get
        {
            var total = 0.0;
            foreach (var cart in CartItems)
            {
                total += cart.TotalPriceWithoutDiscount * (1 - cart.Discount);
            }
            
            return Convert.ToDecimal(total);
        }
    }

    public DateTime TimeOfOrder { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public record CartItem(string OrderId, string ProductId, int Quantity, double TotalPriceWithoutDiscount, double Discount);
