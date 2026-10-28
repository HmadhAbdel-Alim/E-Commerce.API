using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity
{
    public class Review: BaseClass
    {
        public Review()
        {

        }
        public Review(string userId, string productId, string comment, int rating)
        {
            UserId = userId;
            ProductId = productId;
            Comment = comment;
            Rating = rating;
        }
        public string UserId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
