using E_Commerce.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs.OrderDto
{
    public class OrderCreateDto
    {
        public string BuyEmail { get; set; } = string.Empty;
        public string BasketId { get; set; } = string.Empty;
        public AddressDto? ShippingAdDress { get; set; }
        public int DeliveryMethodID { get; set; }

    }
}
