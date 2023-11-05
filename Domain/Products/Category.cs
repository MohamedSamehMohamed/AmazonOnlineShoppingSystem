namespace Domain.Products;

public class Category
{
    public Category(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; } = new();
}