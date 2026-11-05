using E_Commerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interface
{
    public interface IPaymentService
    {
        Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId);
        Task<string?> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<string?> UpdateOrderPaymentFailed(string paymentIntentId);

        Task HandleStripeWebhookEventAsync(string json, string stripeSignature);
    }
}
