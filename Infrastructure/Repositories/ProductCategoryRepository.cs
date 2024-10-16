using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductCategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
    {
        return await _dbContext.ProductCategories.ToListAsync();
    }

    public async Task<ProductCategory?> GetByIdAsync(int id)
    {
        return await _dbContext.ProductCategories.
            FirstOrDefaultAsync(productCategory => productCategory.Id == id);
    }
    
    public async Task<ProductCategory?> GetByNameAsync(string name)
    {
        return await _dbContext.ProductCategories.
            FirstOrDefaultAsync(productCategory => productCategory.Name == name);
    }

    public async Task AddAsync(ProductCategory productCategory)
    {
        await _dbContext.ProductCategories.AddAsync(productCategory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductCategory productCategory)
    {
        _dbContext.ProductCategories.Update(productCategory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProductCategory productCategory)
    {
        _dbContext.ProductCategories.Remove(productCategory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsCategoryExistsAsync(int id)
    {
        var existingCategory =
            await _dbContext.ProductCategories.FirstOrDefaultAsync(productCategory => productCategory.Id == id);

        return existingCategory != null;
    }
}