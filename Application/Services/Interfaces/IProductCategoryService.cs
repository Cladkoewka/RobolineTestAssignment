using Application.DTOs.ProductCategory;

namespace Application.Services.Interfaces;

public interface IProductCategoryService
{
    Task<IEnumerable<GetProductCategoryDto>> GetAllProductCategoriesAsync();
    Task<GetProductCategoryDto?> GetProductCategoryByIdAsync(int id);
    Task<GetProductCategoryDto?> CreateProductCategoryAsync(CreateProductCategoryDto createProductCategoryDto);
    Task<bool> UpdateProductCategoryAsync(int id, UpdateProductCategoryDto updateProductCategoryDto);
    Task<bool> DeleteProductCategoryAsync(int id);
}