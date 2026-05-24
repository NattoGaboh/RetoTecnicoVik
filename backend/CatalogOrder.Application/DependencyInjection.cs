using CatalogOrder.Application.Auth.Services;
using CatalogOrder.Application.Categories.Services;
using CatalogOrder.Application.Orders.Services;
using CatalogOrder.Application.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogOrder.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<AuthService>();

            services.AddScoped<CategoryService>();

            services.AddScoped<ProductService>();

            services.AddScoped<OrderService>();

            return services;
        }
    }
}
