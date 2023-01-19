using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCorp.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.OrderId).ValueGeneratedOnAdd();
            builder.HasKey(order => order.OrderId);
            builder.HasIndex(order => order.OrderId).IsUnique();
            builder.Property(order => order.ClientFullName).HasMaxLength(250);
        }
    }
}
