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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Total)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Status)
                .HasConversion<string>();

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(100);

            builder.Property(x => x.UpdatedBy)
                .HasMaxLength(100);

            builder.HasMany(x => x.Details)
                .WithOne()
                .HasForeignKey(x => x.OrderId);

            builder.Navigation(x => x.Details)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
