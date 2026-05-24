using CatalogOrder.Domain.Common;
using CatalogOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Domain.Entity
{
    public class Order : AuditableEntity
    {
        private readonly List<OrderDetail> _details = new();

        public IReadOnlyCollection<OrderDetail> Details => _details;

        public decimal Total { get; private set; }

        public OrderStatus Status { get; private set; }

        private Order()
        {
        }

        public Order(string createdBy)
        {
            CreatedBy = createdBy;

            Status = OrderStatus.Pending;
        }

        public void AddDetail(Guid productId,int quantity, decimal unitPrice)
        {
            var detail = new OrderDetail(productId,quantity,unitPrice);

            _details.Add(detail);

            RecalculateTotal();
        }

        public void Validate()
        {
            if (!_details.Any())
            {
                throw new DomainException(
                    "La Orden debe contener al menos un item.");
            }
        }

        public void MarkAsProcessed()
        {
            Validate();

            Status = OrderStatus.Processed;
        }

        private void RecalculateTotal()
        {
            Total = _details.Sum(x => x.Subtotal);
        }
    }
}
