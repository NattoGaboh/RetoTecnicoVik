using CatalogOrder.Application.Common.Interfaces;
using CatalogOrder.Application.Orders.DTOs;

namespace CatalogOrder.Api.Services
{
    public class OrderProcessingClient : IOrderProcessingClient
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public OrderProcessingClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<OrderProcessingResponseDto>
            ProcessOrderAsync(
                CreateOrderRequestDto request)
        {
            var internalKey =
                _configuration["InternalService:ApiKey"];

            _httpClient.DefaultRequestHeaders
                .Add("x-internal-key", internalKey);

            var response = await _httpClient.PostAsJsonAsync(
                "/internal/orders/process",
                request);

            if (!response.IsSuccessStatusCode)
            {
                return new OrderProcessingResponseDto
                {
                    Success = false,
                    Message = "Error processing order."
                };
            }

            return await response
                .Content
                .ReadFromJsonAsync<OrderProcessingResponseDto>()
                ?? new OrderProcessingResponseDto
                {
                    Success = false,
                    Message = "Invalid response."
                };
        }
    }
}
