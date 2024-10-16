using Application.DTOs.ProductCategory;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetProductCategoryDto>))]  
    public async Task<ActionResult<IEnumerable<GetProductCategoryDto>>> GetAllProductCategories()
    {
        var productCategories = await _productCategoryService.GetAllProductCategoriesAsync();
        return Ok(productCategories);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductCategoryDto))]  
    [ProducesResponseType(StatusCodes.Status404NotFound)]  
    public async Task<ActionResult<GetProductCategoryDto>> GetProductCategoryById(int id)
    {
        var productCategory = await _productCategoryService.GetProductCategoryByIdAsync(id);
        if (productCategory == null)
            return NotFound($"Product category with Id {id} not found");

        return Ok(productCategory);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetProductCategoryDto))]  
    [ProducesResponseType(StatusCodes.Status400BadRequest)]  
    public async Task<ActionResult<GetProductCategoryDto>> AddProductCategory(
        [FromBody] CreateProductCategoryDto createProductCategoryDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdProductCategory = await _productCategoryService.CreateProductCategoryAsync(createProductCategoryDto);
        
        if (createdProductCategory == null)
            return BadRequest("Product category could not be created");

        return CreatedAtAction(nameof(GetProductCategoryById), new { id = createdProductCategory.Id },
            createdProductCategory);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]  
    [ProducesResponseType(StatusCodes.Status400BadRequest)]  
    [ProducesResponseType(StatusCodes.Status404NotFound)]  
    public async Task<ActionResult> UpdateProductCategory(int id,
        [FromBody] UpdateProductCategoryDto updateProductCategoryDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var isUpdated = await _productCategoryService.UpdateProductCategoryAsync(id, updateProductCategoryDto);
        if (!isUpdated)
            return NotFound($"Product category with Id {id} not found");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]  
    [ProducesResponseType(StatusCodes.Status404NotFound)]  
    public async Task<ActionResult> DeleteProductCategory(int id)
    {
        var isDeleted = await _productCategoryService.DeleteProductCategoryAsync(id);
        if (!isDeleted)
            return NotFound($"Product category with Id {id} not found");

        return NoContent();
    }
}