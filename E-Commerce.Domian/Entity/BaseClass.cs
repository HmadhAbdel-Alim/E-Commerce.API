using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity
{
    public class BaseClass
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DeleteAt { get; set; } = DateTime.UtcNow;
    }
}
