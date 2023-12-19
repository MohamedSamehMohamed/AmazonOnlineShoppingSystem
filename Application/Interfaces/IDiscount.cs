namespace Domain.Products;

public interface IDiscount
{
    public Discount Get(string productId);
    public bool Add(Discount newDiscount);
    public bool Remove(string productId);
    public bool Update(Discount newDiscount);
}