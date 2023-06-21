namespace Domain.Products;

public class Review
{
    public int ClientId { get; set; }
    public int ProductId { get; set; }
    public string Comment { get; set; } = "";
    public int Rating { get; set; }
}