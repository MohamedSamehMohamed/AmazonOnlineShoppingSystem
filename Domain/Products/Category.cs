namespace Domain.Products;

public class Category
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; } = new();
}