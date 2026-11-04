using E_Commerce.Application.DTOs.ProductDto;
using E_Commerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandService brandService;
        public BrandController(BrandService _brandService)
        {
            brandService = _brandService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductBrandDto>> GetAllBrandsAsync()
        {
            var brand = await brandService.GetAllBrandAsync();
            return Ok(brand);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductBrandDto>> GetBrandByIdAsync(int Id)
        {
            var brand = await brandService.GetBrandByIdAsync(Id);
            return Ok(brand);
        }
        [HttpPost]
        public async Task<ActionResult<ProductBrandDto>> CreateBrandAsync(ProductBrandDto brandDto)
        {
            var brand = await brandService.CreateBrandAsync(brandDto);
            return Ok(brand);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateBrandAsync(int Id , ProductBrandDto dto)
        {
          var brand=  await brandService.UpdateBrandAsync(Id, dto);
            return Ok(brand);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBrandAsync(int Id)
        {
            await brandService.DeleteBrandAsync(Id);
            return NoContent();
        }
    }
}
