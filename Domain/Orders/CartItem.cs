using Domain.Products;

namespace Domain.Orders;

public class CartItem
{
    public List<Product> Products { get; set; } = new();
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }

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