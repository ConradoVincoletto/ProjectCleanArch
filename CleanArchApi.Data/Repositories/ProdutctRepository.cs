using CleanArch.Data.Context;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProdutctRepository : IProductRepository
{
    ApplicationDbContext _categoryContext;

    public ProdutctRepository(ApplicationDbContext categoryContext)
    {
        _categoryContext = categoryContext;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _categoryContext.Add(product);
        await _categoryContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetByIdAsync(int? id)
        => await _categoryContext.Products.FindAsync(id);


    public async Task<IEnumerable<Product>> GetProductAsync() 
        => await _categoryContext.Products.ToListAsync();

    public async Task<Product> RemoveAsync(Product product)
    {
        _categoryContext.Remove(product);
        await _categoryContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _categoryContext.Update(product);
        await _categoryContext.SaveChangesAsync();
        return product;
    }
}
