using Domain.Products;

namespace Application.Data.MockRepositories;

public class MockCategoryRepository: ICategoryRepository
{
    private List<Category> _categories = new List<Category>()
    {
        new Category { Id = "1", Description = "this is a category 1" },
        new Category { Id = "2", Description = "this is a category 2" },
        new Category { Id = "3", Description = "this is a category 3" }
    };
    public async Task<Category?> Get(string categoryId)
    {
        return  _categories.Find(category => category.Id.Equals(categoryId));
    }
}