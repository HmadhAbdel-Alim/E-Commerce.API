using E_Commerce.Application.Interface;
using E_Commerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class BasketService
    {
        private readonly IBasketRepository _basketRepository;
        
        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasket?> GetBasketByIdAsync(string basketId)
        {
            return await _basketRepository.GetBasketAsync(basketId);
        }
        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            return await _basketRepository.UpdateBasketAsync(basket);
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _basketRepository.DeleteBasketAsync(basketId);
        }
    }
}
