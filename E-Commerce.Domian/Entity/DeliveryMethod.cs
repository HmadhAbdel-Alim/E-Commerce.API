using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity
{
    public class DeliveryMethod: BaseClass
    {
        public DeliveryMethod() { }
        public DeliveryMethod(string shortName, string description, decimal price, string deliveryTime)
        {
            ShortName = shortName;
            Description = description;
            Price = price;
            DeliveryTime = deliveryTime;
        }
        public string ShortName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string DeliveryTime { get; set; } = string.Empty;
    }
}
