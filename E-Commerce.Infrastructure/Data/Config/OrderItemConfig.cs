using E_Commerce.Domian.Entity.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Config
{
    public class OrderItemConfig: IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderItems> builder)
        {
            builder.Property(oi => oi.Id).IsRequired();
            builder.Property(oi => oi.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.HasOne(oi => oi.Order).WithMany(o => o.OrderItems).HasForeignKey(oi => oi.OrderId);
            builder.OwnsOne(oi => oi.ItemOrdered, io =>
            {
                io.Property(i => i.ProductItemId).IsRequired();
                io.Property(i => i.ProductName).IsRequired().HasMaxLength(100);
                io.Property(i => i.PictureUrl).IsRequired();
                io.Property(i => i.ProductDescription).IsRequired().HasMaxLength(200);
                io.Property(i => i.Price).IsRequired().HasColumnType("decimal(18,2)");
            });

        }
    }
}
