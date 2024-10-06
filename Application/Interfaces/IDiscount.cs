namespace Domain.Products;

public interface IDiscount
{
    public Discount? Get(string productId);
    public void Add(Discount newDiscount);
    public void Invalidate(string productId);
}