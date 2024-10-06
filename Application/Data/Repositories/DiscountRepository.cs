using Domain.Products;

namespace Application.Data.Repositories;

public class DiscountRepository: IDiscount
{
    private readonly ApplicationContext _context;

    public DiscountRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Discount? Get(string productId)
    {
        return _context.Discounts.FirstOrDefault(discount => discount.ProductId.Equals(productId) && 
                                                             discount.StartDate >= DateTime.Now && 
                                                             (discount.EndDate == null || discount.EndDate < DateTime.Now));
    }

    public void Add(Discount newDiscount)
    {
        _context.Discounts.Add(newDiscount);
    }

    public void Invalidate(string productId)
    {
        var discount = Get(productId);
        if (discount != null)
        {
            discount.EndDate = DateTime.Now;
        }
    }
}