using CatalogOrder.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Category> Categories { get; }

        DbSet<Product> Products { get; }

        DbSet<Order> Orders { get; }

        DbSet<OrderDetail> OrderDetails { get; }

        DbSet<AppUser> Users { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
