using Domain.Products;

namespace Application.Data.Repositories;

public class DiscountRepository: IDiscount
{
    private readonly ApplicationContext _context;

    public DiscountRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Discount Get(string productId)
    {
        return _context.Discounts.FirstOrDefault(discount => discount.ProductId.Equals(productId));
    }

    public bool Add(Discount newDiscount)
    {
        try
        {
            var oldDiscount = Get(newDiscount.ProductId);
            if (oldDiscount == null)
            {
                _context.Discounts.Add(newDiscount);
            }
            else
            {
                oldDiscount.DiscountPercent = newDiscount.DiscountPercent;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Remove(string productId)
    {
        try
        {
            var discount = Get(productId);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(Discount newDiscount)
    {
        return Add(newDiscount);
    }
}