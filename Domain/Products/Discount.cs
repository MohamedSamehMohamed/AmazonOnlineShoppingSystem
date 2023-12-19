using Microsoft.EntityFrameworkCore;

namespace Domain.Products;

public class Discount
{
    public string DiscountId { get; set; } = Guid.NewGuid().ToString();
    public string ProductId { get; set; }
    public Product Product { get; set; }
    public double DiscountPercent { get; set; }
}