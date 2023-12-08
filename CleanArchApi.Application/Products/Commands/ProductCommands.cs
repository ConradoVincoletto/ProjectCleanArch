using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands
{
    public abstract class ProductCommands : IRequest<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }

      
    }
}
