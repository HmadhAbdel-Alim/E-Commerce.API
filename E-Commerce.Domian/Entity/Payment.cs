using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity
{
    public class Payment:BaseClass
    {
        public Payment()
        {
            
        }

        public Payment(string paymentIntentID,string clientSecret,decimal amount)
        {
            PaymentIntentID = paymentIntentID;
            ClientSecret = clientSecret;
            Amount = amount;
        }
        public string PaymentIntentID { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
