using Application.DTOs.ProductCategory;

namespace Application.DTOs.Product;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public GetProductCategoryDto Category { get; set; }
}