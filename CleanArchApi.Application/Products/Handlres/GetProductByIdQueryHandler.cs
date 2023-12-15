using CleanArchMcv.Application.Products.Queries;
using CleanArchMcv.Domain.Entities;
using CleanArchMcv.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMcv.Application.Products.Handlres;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository
            ?? throw new ArgumentException(nameof(productRepository));
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdAsync(request.Id);

    }
}
