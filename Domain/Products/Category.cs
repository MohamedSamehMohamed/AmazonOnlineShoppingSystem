namespace Domain.Products;

public class Category
{
    public Category()
    {
        
    }
    public Category(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<Product> Products { get; set; } = new();
}