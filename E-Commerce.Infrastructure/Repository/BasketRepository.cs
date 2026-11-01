using E_Commerce.Application.Interface;
using E_Commerce.Domian.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly StackExchange.Redis.IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<CustomerBasket?> GetBasketAsync(string buyerId)
        {
            var data = await _database.StringGetAsync(buyerId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data!);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            return created ? basket : null;
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            var deleted = await _database.KeyDeleteAsync(basketId);
            return deleted;
        }
    }
}
