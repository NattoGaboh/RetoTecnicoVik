using CatalogOrder.Application.Common.Interfaces;
using CatalogOrder.Application.Common.Models;
using CatalogOrder.Application.Orders.DTOs;
using System.Text.Json;

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
            ProcessOrderAsync(CreateOrderRequestDto request)
        {
            var internalKey = _configuration["InternalService:ApiKey"];

            _httpClient.DefaultRequestHeaders.Add("x-internal-key", internalKey);
      
            var response = await _httpClient.PostAsJsonAsync("/internal/orders/process", request);
            var jsonRaw = await response.Content.ReadAsStringAsync();
            //var json = JsonSerializer.Deserialize<OrderProcessingResponseDto>(jsonRaw);
            //string? message = json?.Message;
            var doc = JsonDocument.Parse(jsonRaw);
            string message = doc.RootElement.GetProperty("message").GetString();

            if (!response.IsSuccessStatusCode)
            {
                return new OrderProcessingResponseDto
                {
                    Success = false,
                    Message = message ?? "Error procesando la orden"
                };
            }

            return await response.Content.ReadFromJsonAsync<OrderProcessingResponseDto>()
                ?? new OrderProcessingResponseDto
                {
                    Success = false,
                    Message = "Response inválido"
                };
        }
    }
}
