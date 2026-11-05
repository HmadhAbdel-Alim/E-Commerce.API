using E_Commerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interface
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string buyerId);
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string buyerId);
    }
}
