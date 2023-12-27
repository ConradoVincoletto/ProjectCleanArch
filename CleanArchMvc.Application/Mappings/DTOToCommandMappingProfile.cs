using AutoMapper;
using CleanArchMcv.Application.DTOs;
using CleanArchMcv.Application.Products.Commands;

namespace CleanArchMcv.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
