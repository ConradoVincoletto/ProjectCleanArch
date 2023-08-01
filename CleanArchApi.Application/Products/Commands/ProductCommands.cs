using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Commands
{
    public abstract class ProductCommands : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; private set; }
    }
}
