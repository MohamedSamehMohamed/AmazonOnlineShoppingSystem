using System.ComponentModel.DataAnnotations;

namespace Domain.Products;

public class Product
{
    [Key] 
    public string ProductId { get; set; } = Guid.NewGuid().ToString();
    public string ProductOwner { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double Price { get; set; }
    public int AvailableItemCount { get; set; }
    public string CategoryId { get; set; }
    public Category Category { get; set; }
    public Discount Discount { get; set; }
    
}