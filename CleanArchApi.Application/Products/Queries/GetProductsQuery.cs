using CleanArch.Domain.Entities;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
