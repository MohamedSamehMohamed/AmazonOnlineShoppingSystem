using Domain.Products;

namespace Domain.Orders;

public class CartItem
{
    public List<Product> Products { get;} = new();
    public int Quantity { get; private set; }
    public double TotalPrice { get; private set; }

    public bool AddProduct(Product product)
    {
        try
        {
            Products.Add(product);
            TotalPrice += product.Price * product.AvailableItemCount;
            Quantity += product.AvailableItemCount;
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool RemoveProduct(Product product)
    {
        if (Products.Remove(product))
        {
            TotalPrice -= product.Price * product.AvailableItemCount;
            Quantity -= product.AvailableItemCount;
        }
        return true;
    }
    public bool CheckOut()
    {
        return true;
    }
}