namespace OrderProcessingServices.DTOs
{
    public class ProcessedOrderItemDto
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal { get; set; }
    }
}
