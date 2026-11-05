using E_Commerce.Application.Services;
using E_Commerce.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketService _basketService;
        public BasketController(BasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("{basketId}")]
        public async Task<ActionResult<CustomerBasket?>> GetBasketById(string basketId)
        {
            var basket = await _basketService.GetBasketByIdAsync(basketId);
            if (basket == null)
            {
                return NotFound();
            }
            return Ok(basket);
        }
        [HttpPut]   
        public async Task<ActionResult<CustomerBasket?>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketService.UpdateBasketAsync(basket);
            if (updatedBasket == null)
            {
                return NotFound();
            }
            return Ok(updatedBasket);
        }
        [HttpDelete("{basketId}")]
        public async Task<ActionResult<bool>> DeleteBasket(string basketId)
        {
            var result = await _basketService.DeleteBasketAsync(basketId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
