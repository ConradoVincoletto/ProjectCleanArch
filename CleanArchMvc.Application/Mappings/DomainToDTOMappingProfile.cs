using AutoMapper;
using CleanArchMcv.Application.DTOs;
using CleanArchMcv.Domain.Entities;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMcv.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public  DomainToDTOMappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
