using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMcv.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
