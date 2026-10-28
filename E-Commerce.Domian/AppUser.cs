using E_Commerce.Domian.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;
    }
}
