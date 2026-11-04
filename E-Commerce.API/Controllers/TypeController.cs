using E_Commerce.Application.DTOs.ProductDto;
using E_Commerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly TypeService TypeService;
        public TypeController(TypeService _TypeService)
        {
            TypeService = _TypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductTypeDto>> GetAllTypesAsync()
        {
            var Type = await TypeService.GetAllTypeAsync();
            return Ok(Type);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductTypeDto>> GetTypeByIdAsync(int Id)
        {
            var Type = await TypeService.GetTypeByIdAsync(Id);
            return Ok(Type);
        }
        [HttpPost]
        public async Task<ActionResult<ProductTypeDto>> CreateTypeAsync(ProductTypeDto TypeDto)
        {
            var Type = await TypeService.CreateTypeAsync(TypeDto);
            return Ok(Type);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateTypeAsync(int Id, ProductTypeDto dto)
        {
            var Type = await TypeService.UpdateTypeAsync(Id, dto);
            return Ok(Type);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTypeAsync(int Id)
        {
            await TypeService.DeleteTypeAsync(Id);
            return NoContent();
        }
    }
}
