using Microsoft.EntityFrameworkCore;

namespace Domain.Products;

public class Discount
{
    public string DiscountId { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
    public double DiscountPercent { get; set; }
}