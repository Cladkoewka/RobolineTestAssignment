using Application.DTOs.Product;
using Domain.Entities;

namespace Application.Mapping;

public static class ProductMapper
{
    public static GetProductDto MapToGetDto(this Product product)
    {
        return new GetProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category.MapToGetDto()
        };
    }

    public static Product MapToEntity(this CreateProductDto createProductDto)
    {
        return new Product
        {
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
            CategoryId = createProductDto.CategoryId
        };
    }
    
    public static void UpdateEntity(this Product product, UpdateProductDto updateProductDto)
    {
        product.Name = updateProductDto.Name;
        product.Description = updateProductDto.Description;
        product.Price = updateProductDto.Price;
        product.CategoryId = updateProductDto.CategoryId;
    }
}