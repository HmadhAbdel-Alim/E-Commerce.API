using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs.OrderDto
{
    public class OrderToReturnDto
    {
        public int ID { get; set; }
        public string BuyEmail { get; set; }=string.Empty;
        public DateTime OrderDate { get; set; }
        public AddressDto? ShippingAddress { get; set; }
        public string DeliveryMethod { get; set; } = string.Empty;
        public int DeliveryMethodID { get; set; }
        public decimal ShippingPrice { get; set; }
        public IReadOnlyList<OrderItemDto>? OrderItem { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GetTotal { get; set; }
        public string Status { get; set; } = string.Empty;

    }
}
