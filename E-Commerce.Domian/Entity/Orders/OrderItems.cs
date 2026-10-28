using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity.Orders
{
    public class OrderItems: BaseClass
    {
        public OrderItems() { }
        public OrderItems(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }
        public ProductItemOrdered ItemOrdered { get; set; } = new ProductItemOrdered();
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
