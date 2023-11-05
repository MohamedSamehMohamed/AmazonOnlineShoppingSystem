namespace Domain.Products;

public class Review
{
    public Review(Guid clientId, Guid productId, string comment, int rating)
    {
        ClientId = clientId;
        ProductId = productId;
        Comment = comment;
        Rating = rating;
    }

    public Guid ClientId { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}