namespace Application.Dto.Products;

public record CreateProductDto(
    string Name, 
    string Description, 
    string ImageUrl, 
    double Price, 
    int AvailableItemCount,
    string CategoryId);