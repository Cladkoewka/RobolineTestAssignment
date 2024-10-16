using Application.DTOs.ProductCategory;
using Domain.Entities;

namespace Application.Mapping;

public static class ProductCategoryMapper
{
    public static GetProductCategoryDto MapToGetDto(this ProductCategory productCategory)
    {
        return new GetProductCategoryDto
        {
            Id = productCategory.Id,
            Name = productCategory.Name,
            Description = productCategory.Description
        };
    }

    public static ProductCategory MapToEntity(this CreateProductCategoryDto createProductCategoryDto)
    {
        return new ProductCategory
        {
            Name = createProductCategoryDto.Name,
            Description = createProductCategoryDto.Description
        };
    }
    
    public static void UpdateEntity(this ProductCategory productCategory, 
        UpdateProductCategoryDto updateProductCategoryDto)
    {
        productCategory.Name = updateProductCategoryDto.Name;
        productCategory.Description = updateProductCategoryDto.Description;
    }
}