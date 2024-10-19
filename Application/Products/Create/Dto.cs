namespace Application.Products.Create;

public static class Dto
{
    public static CreateProductResponse NotFoundCategory(string categoryId) => new CreateProductResponse("", false, new List<string> { $"Category ID {categoryId} not found" });
    public static CreateProductResponse FailedToAddProduct(string errorMessage) => new CreateProductResponse("", false, new List<string> { $"Un able to add the product due to error: {errorMessage}" });
}