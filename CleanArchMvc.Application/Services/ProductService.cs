using AutoMapper;
using CleanArchMcv.Application.DTOs;
using CleanArchMcv.Application.Interfaces;
using CleanArchMcv.Application.Products.Commands;
using CleanArchMcv.Application.Products.Queries;
using MediatR;

namespace CleanArchMcv.Application.Services;
public class ProductService : IProductService
{

    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsQUery = new GetProductsQuery();

        if (productsQUery == null)
        {
            throw new Exception("Entity could not be loaded.");
        }

        var result = await _mediator.Send(productsQUery);

        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task Add(ProductDTO productDTO)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);

        await _mediator.Send(productCreateCommand);
    }

    public async Task<ProductDTO> GetById(int? id)
    {
        var productById = new GetProductByIdQuery(id.Value);

        if (productById == null)
        {
            throw new Exception("Entity could not be loaded.");
        }

        var result = await _mediator.Send(productById);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        var productCategory = new GetProductByIdQuery(id.Value);

        if (productCategory == null)
        {
            throw new Exception("Entity could not be loaded.");
        }

        var result = await _mediator.Send(productCategory);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task Remove(int? id)
    {
        var productRemoveCommand = new ProductRemoveCommand(id.Value);
        if (productRemoveCommand == null)
        {
            throw new Exception("Entity could not be loaded.");
        }

        await _mediator.Send(productRemoveCommand);
    }

    public async Task Update(ProductDTO productDTO)
    {
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

        await _mediator.Send(productUpdateCommand);
    }
}