using Application.DTOs.Product;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetProductDto>))]  
    public async Task<ActionResult<IEnumerable<GetProductDto>>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductDto))]  
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<ActionResult<GetProductDto>> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound($"Product with Id {id} not found");

        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetProductDto))]  
    [ProducesResponseType(StatusCodes.Status400BadRequest)]  
    public async Task<ActionResult<GetProductDto>> AddProduct([FromBody] CreateProductDto createProductDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdProduct = await _productService.CreateProductAsync(createProductDto);

        if (createdProduct == null)
            return BadRequest("Product could not be created");

        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]  
    [ProducesResponseType(StatusCodes.Status400BadRequest)]  
    [ProducesResponseType(StatusCodes.Status404NotFound)]  
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var isUpdated = await _productService.UpdateProductAsync(id, updateProductDto);
        if (!isUpdated)
            return NotFound($"Product with Id {id} not found");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]  
    [ProducesResponseType(StatusCodes.Status404NotFound)]  
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var isDeleted = await _productService.DeleteProductAsync(id);
        if (!isDeleted)
            return NotFound($"Product with Id {id} not found");

        return NoContent();
    }
    
}