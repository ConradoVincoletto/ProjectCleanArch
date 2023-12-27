using AutoMapper;
using CleanArchMcv.Application.DTOs;
using CleanArchMcv.Application.Interfaces;
using CleanArchMcv.Domain.Entities;
using CleanArchMcv.Domain.Interfaces;

namespace CleanArchMcv.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRespository _categoryRespository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRespository categoryRespository, IMapper mapper)
    {
        _categoryRespository = categoryRespository;
        _mapper = mapper;
    }

    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRespository.Create(categoryEntity);
    }

    public async Task<CategoryDTO> GetById(int? id)
    {
        var categoryEntity = await _categoryRespository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRespository.GetCategories();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task Remove(int? id)
    {
        var categoryEntity = _categoryRespository.GetById(id).Result;
        await _categoryRespository.Remove(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRespository.Update(categoryEntity);
    }
}
