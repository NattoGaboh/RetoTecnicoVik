using CatalogOrder.Domain.Entity;
using CatalogOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Infrastructure.Persistence.Seeds
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var admin = new AppUser(
                "admin",
                BCrypt.Net.BCrypt.HashPassword("Admin321"),
                UserRole.Admin);

            var operatorUser = new AppUser(
                "operator",
                BCrypt.Net.BCrypt.HashPassword("Operador432"),
                UserRole.Operator);

            var category = new Category(
                "Electronicos",
                "seed");

            var product = new Product(
                "Mouse",
                "Gamer Mouse",
                250,
                15,
                category.Id,
                "seed");

            await context.Users.AddRangeAsync(admin, operatorUser);

            await context.Categories.AddAsync(category);

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();
        }
    }
}
