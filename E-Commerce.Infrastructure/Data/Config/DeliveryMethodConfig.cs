using E_Commerce.Domian.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Config
{
    public class DeliveryMethodConfig : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(dm => dm.Id).IsRequired();
            builder.Property(dm => dm.ShortName).IsRequired().HasMaxLength(100);
            builder.Property(dm => dm.Description).IsRequired().HasMaxLength(200);
            builder.Property(dm => dm.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
