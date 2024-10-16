using Application.DTOs.Product;

namespace Application.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
    Task<GetProductDto?> GetProductByIdAsync(int id);
    Task<GetProductDto?> CreateProductAsync(CreateProductDto createProductDto);
    Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
    Task<bool> DeleteProductAsync(int id);
}