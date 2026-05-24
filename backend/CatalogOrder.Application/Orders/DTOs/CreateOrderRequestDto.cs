using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Orders.DTOs
{
    public class CreateOrderRequestDto
    {
        public List<CreateOrderItemDto> Items { get; set; }  = [];
    }
}
