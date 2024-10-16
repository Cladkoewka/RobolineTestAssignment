using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductCategoryRepository
{
    Task<IEnumerable<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(int id);
    Task<ProductCategory?> GetByNameAsync(string name);
    Task AddAsync(ProductCategory productCategory);
    Task UpdateAsync(ProductCategory productCategory);
    Task DeleteAsync(ProductCategory productCategory);
    Task<bool> IsCategoryExistsAsync(int id);
}