namespace Application.Products.Create;

public record CreateProductResponse(string ProductId, bool Succeed, List<string> Errors);