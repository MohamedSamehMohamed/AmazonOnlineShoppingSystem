namespace Application.Products.DTO;

public record CreateProductDTO(
    string Name, 
    string Description, 
    string ImageUrl, 
    double Price, 
    int AvailableItemCount,
    string CategoryId);