using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using MediatR;
namespace CleanArch.Application.Products.Handlres
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, 
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductAsync();
        }
    }
}
