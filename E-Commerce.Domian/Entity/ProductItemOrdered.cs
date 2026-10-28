using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered() { }
        public ProductItemOrdered(string productName, string pictureUrl,int productItemId, string productDescription, decimal price)
        {
            ProductName = productName;
            PictureUrl = pictureUrl;
            ProductItemId = productItemId;
            ProductDescription = productDescription;
            Price = price;
        }

        public string ProductName { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public int ProductItemId { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
