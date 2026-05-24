using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Orders.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        public string Status { get; set; } = string.Empty;

        public List<OrderDetailDto> Details { get; set; } = [];
    }
}
