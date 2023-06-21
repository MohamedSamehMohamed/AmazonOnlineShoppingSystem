namespace Domain.Orders;

public class Order
{
    public int ClientId { get; set; }
    public CartItem CartItem { get; set; } = new();
    public DateTime TimeOfOrder { get; set; } = DateTime.Now;
}