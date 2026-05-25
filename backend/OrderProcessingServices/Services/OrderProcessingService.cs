using OrderProcessingServices.DTOs;
using CatalogOrder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace OrderProcessingServices.Services
{
    public class OrderProcessingService
    {
        private readonly AppDbContext _context;

        public OrderProcessingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderProcessingResponseDto>

        ProcessAsync(CreateOrderRequestDto request)
        {
            if (request.Items == null || request.Items.Count == 0)
            {
                return new OrderProcessingResponseDto
                {
                    Success = false,
                    Message = "La Orden debe contener items."
                };
            }

            var processedItems = new List<ProcessedOrderItemDto>();

            decimal total = 0;


            foreach (var item in request.Items)
            {
                if (item.Quantity <= 0)
                {
                    return new OrderProcessingResponseDto
                    {
                        Success = false,
                        Message = "La cantidad debe ser mayor que 0."
                    };
                }

                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId);

                if (product == null)
                {
                    return new OrderProcessingResponseDto
                    {
                        Success = false,
                        Message = "Producto no encontrado."
                    };
                }

                if (!product.IsActive)
                {
                    return new OrderProcessingResponseDto
                    {
                        Success = false,
                        Message = $"Producto {product.Name} está inactivo."
                    };
                }


                if (product.Stock < item.Quantity)
                {
                    return new OrderProcessingResponseDto
                    {
                        Success = false,
                        Message = $"Stock insuficiente para producto {product.Name}."
                    };
                }


                var subtotal = product.Price * item.Quantity;

                total += subtotal;

                processedItems.Add(new ProcessedOrderItemDto
                    {
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price,
                        Subtotal = subtotal
                    });
            }


            return new OrderProcessingResponseDto
            {
                Success = true,
                Message = "Orden procesada satisfactoriamente.",
                Total = total,
                Items = processedItems
            };
        }
    }

}
