using E_Commerce.Domian.Entity.ProductEntity;
using E_Commerce.Domian.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity.Orders
{
    public class Order:BaseClass
    {
        public Order() { }
        public Order(IReadOnlyList<OrderItems> orderItems, decimal subtotal, DeliveryMethod? deliveryMethod,string buyEmail,Adress? shippingAdress,string paymentIntentId)
        {
            OrderItems = orderItems;
            Subtotal = subtotal;
            DeliveryMethod = deliveryMethod;
            BuyEmail = buyEmail;
            ShippingAdress = shippingAdress;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Adress? ShippingAdress { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
        public Payment? payment { get; set; }
        public IReadOnlyList<OrderItems>? OrderItems { get; set; } = new List<OrderItems>();
        public decimal Subtotal { get; set; }
        public int DeliveryMethodID { get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
        public OrderStatus Status { get; set; }
        public decimal GetTotal () => Subtotal + (DeliveryMethod?.Price ?? 0);

    }
}
