﻿using CleanArchMcv.Domain.Entities;
using CleanArchMcv.Domain.Interfaces;
using CleanArchMvc.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMcv.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    ApplicationDbContext _categoryContext;

    public CategoryRepository(ApplicationDbContext categoryContext)
    {
        _categoryContext = categoryContext;
    }

    public async Task<Category> Create(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> GetById(int? id)
        => await _categoryContext.Categories.FindAsync(id);

    public async Task<IEnumerable<Category>> GetCategories()
        => await _categoryContext.Categories.ToListAsync();

    public async Task<Category> Remove(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
