namespace OrderProcessingServices.DTOs
{

    public class CreateOrderRequestDto
    {
        public List<CreateOrderItemDto> Items { get; set; } = [];
    }
}
