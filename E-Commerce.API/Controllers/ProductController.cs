using E_Commerce.Application.DTOs.ProductDto;
using E_Commerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Products")]
        public async Task<ActionResult<ProductToReturnDto>> GetALlProductsAsync()
        {
            var product = await _productService.GetAllProductAsync();
            return Ok(product);
        }

        [HttpGet("ProductID")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null) { return BadRequest(new{Message = "Product Id not found"}); }
            return Ok(product);
        }

        [HttpPost("Add Product")]
        public async Task<ActionResult<ProductToReturnDto>> CreateProductAsync(ProductCreateDto productDto)
        {
            var product = await _productService.CreateProductAsync(productDto);
            return Ok(product);
        }
        [HttpPut("Update Product")]

        public async Task<ActionResult<ProductToReturnDto>> UpdateProductAsync(int id,ProductCreateDto dto )
        {
            var product =  _productService.UpdateProductAsync(id,dto);
            if (product == null) { return NotFound(new { message = "Product Not Found" }); }
            return Ok(product);
        }
        [HttpDelete("Delete Product")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var product =  _productService.DeleteProductAsync(id);
            return Ok(product);
        }
    }
}
