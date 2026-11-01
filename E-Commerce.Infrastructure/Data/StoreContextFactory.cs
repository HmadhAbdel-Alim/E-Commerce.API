using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {

            {
                var OptionsBuilder = new DbContextOptionsBuilder<StoreContext>();
               OptionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=E-Commerce;Integrated Security =True;TrustServerCertificate=True;");

                return new StoreContext(OptionsBuilder.Options);
            
        
    }
        }
    }
}
