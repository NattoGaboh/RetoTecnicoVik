using CatalogOrder.Application.Common.Interfaces;
using CatalogOrder.Application.Common.Models;
using CatalogOrder.Application.Orders.DTOs;
using CatalogOrder.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CatalogOrder.Application.Orders.Services
{
    public class OrderService
    {
        private readonly IAppDbContext _context;

        private readonly ICurrentUserService _currentUser;

        private readonly IOrderProcessingClient _processingClient;

        public OrderService(
            IAppDbContext context,
            ICurrentUserService currentUser,
            IOrderProcessingClient processingClient)
        {
            _context = context;
            _currentUser = currentUser;
            _processingClient = processingClient;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(
            CreateOrderRequestDto request)
        {
            var processingResult =
                await _processingClient.ProcessOrderAsync(request);

            if (!processingResult.Success)
            {
                return ApiResponse<Guid>.Fail(processingResult.Message);
            }

            var order = new Order(
                _currentUser.Username);

            foreach (var item in processingResult.Items)
            {
                order.AddDetail(
                    item.ProductId,
                    item.Quantity,
                    item.UnitPrice);

                var product = await _context.Products.FirstAsync(x => x.Id == item.ProductId);

                product.ReduceStock(item.Quantity);
            }

            order.Validate();

            order.MarkAsProcessed();

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return ApiResponse<Guid>.Ok(order.Id);
        }
    }
}
