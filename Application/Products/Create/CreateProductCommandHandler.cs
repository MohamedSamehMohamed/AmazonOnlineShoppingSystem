using Application.Data;
using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.Get(request.CategoryId);
        if (category == null) 
            return new CreateProductResponse("", false, 
                new List<string>(){"Category not found"});
        var userId = await _unitOfWork.AuthenticatedUser.GetUserIdByAuthenticationId(request.CreatorId);
        if (userId == "")
            return new CreateProductResponse("", false, 
                new List<string>(){"User Not Found"});
        
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Price = request.Price,
            AvailableItemCount = request.AvailableItemCount,
            CategoryId = request.CategoryId,
            ProductOwner = userId
        };
        if (!await _unitOfWork.ProductRepository.AddAsync(product))
        {
            return new CreateProductResponse("", false, 
                new List<string>(){"Un able to add the product"});
        }
        await _unitOfWork.SaveChangeAsync();
        return new CreateProductResponse(product.ProductId, true, new List<string>());
    }
}