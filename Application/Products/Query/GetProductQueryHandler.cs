using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Query;

public class GetProductQueryHandler: IRequestHandler<GetProductQuery, Product?>
{
    private IUnitOfWork _unitOfWork;
    public GetProductQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return _unitOfWork.ProductRepository.GetAsync(request.ProductId);
    }
}