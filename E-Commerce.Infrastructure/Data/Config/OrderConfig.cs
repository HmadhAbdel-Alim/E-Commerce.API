using E_Commerce.Domian.Entity.Orders;
using E_Commerce.Domian.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Config
{
    public class OrderConfig:IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o.BuyEmail).IsRequired().HasMaxLength(100);
            builder.Property(o => o.OrderDate).IsRequired();
            builder.OwnsOne(o => o.ShippingAdress, na =>
            {
                na.WithOwner();
                na.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
                na.Property(a => a.ListName).IsRequired().HasMaxLength(50);
                na.Property(a => a.Street).IsRequired().HasMaxLength(100);
                na.Property(a => a.City).IsRequired().HasMaxLength(50);
                na.Property(a => a.State).IsRequired().HasMaxLength(50);
                na.Property(a => a.ZipCode).IsRequired().HasMaxLength(20);
                na.Property(a => a.Country).IsRequired().HasMaxLength(50);

            });
            builder.Property(o => o.DeliveryMethodID).IsRequired();
            builder.Property(o => o.Subtotal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(o=> o.Status).HasConversion(
                v => v.ToString(),
                v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v)
            );
            builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);


            builder.OwnsOne(o => o.payment, pi =>
            {
                pi.Property(x=> x.Amount).IsRequired().HasColumnType("decimal(18,2)");
            });

        }
    
    }
}
