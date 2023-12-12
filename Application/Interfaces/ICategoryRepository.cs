namespace Domain.Products;

public interface ICategoryRepository
{
    Task<Category?> Get(string categoryId);
}