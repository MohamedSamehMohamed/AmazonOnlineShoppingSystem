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
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
        AvailableItemCount = availableItemCount;
        Category = category;
    }

    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public double Price { get; set; }
    public int AvailableItemCount { get; set; }
    public Category Category { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}