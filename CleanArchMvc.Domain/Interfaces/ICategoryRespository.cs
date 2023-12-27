using CleanArchMcv.Domain.Entities;

namespace CleanArchMcv.Domain.Interfaces;

public interface ICategoryRespository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category?> GetById(int? id);
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Remove(Category category);


}
