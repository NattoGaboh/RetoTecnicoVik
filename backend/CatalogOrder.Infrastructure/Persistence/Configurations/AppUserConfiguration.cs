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
    public class AppUserConfiguration
        : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(
            EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasConversion<string>();

        }
    }
}