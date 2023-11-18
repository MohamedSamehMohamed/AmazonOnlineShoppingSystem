using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockCategoryRepository: ICategoryRepository
{
    private List<Category> _categories = new List<Category>()
    {
        new Category { Description = "this is a category 1" },
        new Category { Description = "this is a category 2" },
        new Category { Description = "this is a category 3" }
    };
    public async Task<Category?> Get(string categoryId)
    {
        return _categories[1];
    }
}