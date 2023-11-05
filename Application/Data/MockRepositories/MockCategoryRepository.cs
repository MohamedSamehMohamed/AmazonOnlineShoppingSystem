using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockCategoryRepository: ICategoryRepository
{
    private List<Category> _categories = new List<Category>();
    public Task<Category?> Get(string categoryId)
    {
        return Task.FromResult(_categories.FirstOrDefault(category => category.Id.ToString() == categoryId));
    }
}