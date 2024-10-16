using Application.DTOs.ProductCategory;
using Application.Mapping;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Implementations;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<IEnumerable<GetProductCategoryDto>> GetAllProductCategoriesAsync()
    {
        var productCategories = await _productCategoryRepository.GetAllAsync();
        return productCategories.Select(p => p.MapToGetDto());
    }

    public async Task<GetProductCategoryDto?> GetProductCategoryByIdAsync(int id)
    {
        var productCategory = await _productCategoryRepository.GetByIdAsync(id);
        if (productCategory == null)
            return null;

        return productCategory.MapToGetDto();
    }

    public async Task<GetProductCategoryDto?> CreateProductCategoryAsync(CreateProductCategoryDto createProductCategoryDto)
    {
        var existingProductCategory = await _productCategoryRepository.GetByNameAsync(createProductCategoryDto.Name);
        if (existingProductCategory != null)
            return null;

        var productCategory = createProductCategoryDto.MapToEntity();
        await _productCategoryRepository.AddAsync(productCategory);

        return productCategory.MapToGetDto();
    }

    public async Task<bool> UpdateProductCategoryAsync(int id, UpdateProductCategoryDto updateProductCategoryDto)
    {
        var existingProductCategory = await _productCategoryRepository.GetByIdAsync(id);
        if (existingProductCategory == null)
            return false;

        existingProductCategory.UpdateEntity(updateProductCategoryDto);
        await _productCategoryRepository.UpdateAsync(existingProductCategory);
        return true;
    }

    public async Task<bool> DeleteProductCategoryAsync(int id)
    {
        var existingProductCategory = await _productCategoryRepository.GetByIdAsync(id);
        if (existingProductCategory == null)
            return false;

        await _productCategoryRepository.DeleteAsync(existingProductCategory);
        return true;
    }
}