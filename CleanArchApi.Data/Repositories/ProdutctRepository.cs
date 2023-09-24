using CleanArch.Data.Context;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProdutctRepository : IProductRepository
{
    ApplicationDbContext _productContext;

    public ProdutctRepository(ApplicationDbContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<Product?> CreateAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetByIdAsync(int? id)
    {
        return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductAsync() 
        => await _productContext.Products.ToListAsync();

    public async Task<Product?> GetProductCategoryAsync(int? id) 
        => await _productContext.Products.Include(x => x.Category)
            .SingleOrDefaultAsync(p => p.Id == id);


    public async Task<Product?> RemoveAsync(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
