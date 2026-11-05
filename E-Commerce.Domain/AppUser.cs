using E_Commerce.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;
    }
}
