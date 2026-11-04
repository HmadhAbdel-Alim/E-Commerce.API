using E_Commerce.Application.DTOs;
using E_Commerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase
    {
        private readonly DeliveryMethodService service;
        public DeliveryMethodController(DeliveryMethodService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var delivery = await service.GetAllDeliveryMethodAsync();
            return Ok(delivery);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<DeliveryMethodDto>> GetDeliveryMethodById(int Id)
        {
            var delivery = await service.GetDeliveryMethodByIdAsync(Id);
            return Ok(delivery);
        }
        [HttpPost]
        public async Task<ActionResult<DeliveryMethodDto>> CreateDeliveryMethod(DeliveryMethodDto dto)
        {
            var delivery = await service.CeateDeliveryMethodAsync(dto);
            return Ok(delivery);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<DeliveryMethodDto>> UpdateDeliveryMethod(int Id, DeliveryMethodDto dto)
        {
            var delivery = await service.UpdateDeliveryMethodAsync(Id, dto);
            return Ok(delivery);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteDeliveryMethod(int Id)
        {
            await service.DeleteDeliveryMethodAsync(Id);
            return NoContent();
        }

    }
}
