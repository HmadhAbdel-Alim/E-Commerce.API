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

        [HttpGet]
        public async Task<ActionResult<ProductToReturnDto>> GetALlProductsAsync()
        {
            var product = await _productService.GetAllProductAsync();
            return Ok(product);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null) { return BadRequest(new{Message = "Product Id not found"}); }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProductAsync(ProductCreateDto productDto)
        {
            var product = await _productService.CreateProductAsync(productDto);
            return Ok(product);
        }
        [HttpPut("Id")]

        public async Task<ActionResult<ProductToReturnDto>> UpdateProductAsync(int Id,ProductCreateDto dto )
        {
            await  _productService.UpdateProductAsync(Id,dto);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProductAsync(int Id)
        {
            await _productService.DeleteProductAsync(Id);
            return Ok();
        }
    }
}
