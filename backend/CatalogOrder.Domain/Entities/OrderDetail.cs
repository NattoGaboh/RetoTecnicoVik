using CatalogOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Domain.Entity
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; private set; }

        public Guid ProductId { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Subtotal { get; private set; }

        private OrderDetail()
        {
        }

        public OrderDetail(
            Guid productId,
            int quantity,
            decimal unitPrice)
        {
            if (quantity <= 0)
            {
                throw new DomainException(
                    "Cantidad debe ser mayor que 0.");
            }

            if (unitPrice <= 0)
            {
                throw new DomainException(
                    "Precio unitario debe ser mayor que 0.");
            }

            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;

            Subtotal = quantity * unitPrice;
        }
    }
}
