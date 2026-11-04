using E_Commerce.Application.DTOs.OrderDto;
using E_Commerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrders()
        {
            var order = await _orderService.GetAllOrdersAsync();
            return Ok(order);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CraeteOrder(OrderCreateDto Dto)
        {
            var order = await _orderService.CreateOrderAsync(Dto);
            return Ok(order);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateOrder(int id , OrderCreateDto dto)
        {
            await _orderService.UpdateOrderAsync(id, dto);

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
             await _orderService.DeleteOrderAsync(id);
            return NoContent();

        }
    }
}
