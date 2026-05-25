namespace OrderProcessingServices.DTOs
{
    public class OrderProcessingResponseDto
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public List<ProcessedOrderItemDto> Items { get; set; } = [];

    }
}
