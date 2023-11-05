namespace Domain.Products;

public class Product
{
    public Product(
        string name, 
        string description, 
        string imageUrl, 
        double price, 
        int availableItemCount,
        Category category)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
        AvailableItemCount = availableItemCount;
        Category = category;
    }

    public Guid Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double Price { get; set; }
    public int AvailableItemCount { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    
    public List<Review> Reviews { get; set; } = new();
}