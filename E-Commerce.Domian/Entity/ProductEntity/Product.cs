using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity.ProductEntity
{
    public class Product:BaseClass
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int BrandID { get; set; }
        public int TypeID { get; set; }

        public ProductBrand? ProductBrand { get; set; }
        public ProductType? ProductType { get; set; }
    }
}
