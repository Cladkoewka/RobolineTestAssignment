using Application.DTOs.Product;
using Application.Mapping;
using Application.Services.Interfaces;
using Domain.Interfaces;

namespace Application.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => p.MapToGetDto());
    }

    public async Task<GetProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return null;

        return product.MapToGetDto();
    }

    public async Task<GetProductDto?> CreateProductAsync(CreateProductDto createProductDto)
    {
        var isCategoryExists = await _productCategoryRepository.IsCategoryExistsAsync(createProductDto.CategoryId);
        if (!isCategoryExists)
            return null;
        
        var product = createProductDto.MapToEntity();
        
        await _productRepository.AddAsync(product);

        return product.MapToGetDto();
    }

    public async Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
            return false;
        
        var isCategoryExists = await _productCategoryRepository.IsCategoryExistsAsync(updateProductDto.CategoryId);
        if (!isCategoryExists)
            return false;

        existingProduct.UpdateEntity(updateProductDto);
        await _productRepository.UpdateAsync(existingProduct);
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
            return false;

        await _productRepository.DeleteAsync(existingProduct);
        return true;
    }
}