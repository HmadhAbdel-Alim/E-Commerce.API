using E_Commerce.Application.Interface;
using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Entity.ProductEntity;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericRepository<Domain.Entity.ProductEntity.Product> ProductRepo;
        private readonly IGenericRepository<Domain.Entity.Orders.Order> OrderRepo;
        public PaymentService(IConfiguration configuration, IBasketRepository basketRepository, IGenericRepository<Domain.Entity.ProductEntity.Product> productRepo, IGenericRepository<Domain.Entity.Orders.Order> orderRepo   )
        {
            _configuration = configuration;
            _basketRepository = basketRepository;
            ProductRepo = productRepo;
            OrderRepo = orderRepo;
        }
        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket == null) return null;
            var shippingPrice = 0m;

            foreach (var item in basket.Items)
            {
                var productItem = await ProductRepo.GetByIdAsync(item.ProductId);
                if (productItem == null) continue;
                if (productItem.Price != item.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            PaymentIntentService service = new PaymentIntentService();
            PaymentIntent intent;
            
            if(string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)+(shippingPrice * 100)),
                    Currency = "usd",
                    AllowedPaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)),
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }
            await _basketRepository.UpdateBasketAsync(basket);
            return basket;
        }


        public async Task<string?> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            var orders = await OrderRepo.GetAllAsync();
            var order = orders.FirstOrDefault(o => o.PaymentIntentId == paymentIntentId);
            if (order == null) return null;
            order.Status = Domain.Enum.OrderStatus.PaymentFailed;
            await OrderRepo.UpdateAsync(order);
            return order.Id.ToString();
        }

        public async Task<string?> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            var orders = await OrderRepo.GetAllAsync();
            var order = orders.FirstOrDefault(o => o.PaymentIntentId == paymentIntentId);
            if (order == null) return null;
            order.Status = Domain.Enum.OrderStatus.PaymentReceived;
            await OrderRepo.UpdateAsync(order);
            return order.Id.ToString();
        }
        public async Task HandleStripeWebhookEventAsync(string json, string stripeSignature)
        {
            var whSecret = _configuration["StripeSettings:WhSecret"];

            var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, whSecret);

            if (stripeEvent.Type== "payment_intent.succeeded")
            {
                var intent = (PaymentIntent)stripeEvent.Data.Object;
                await UpdateOrderPaymentSucceeded(intent.Id);
            }
            else if (stripeEvent.Type== "payment_intent.failed")
            {
                var intent = (PaymentIntent)stripeEvent.Data.Object;
                await UpdateOrderPaymentFailed(intent.Id);
            }
        }

    }
}
