using CatalogOrder.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Infrastructure.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(
            EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Subtotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
