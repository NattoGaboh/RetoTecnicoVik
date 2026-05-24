using CatalogOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Domain.Entity
{
    public class Product : AuditableEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }

        public bool IsActive { get; private set; }

        private Product()
        {
        }

        public Product(
            string name,
            string description,
            decimal price,
            int stock,
            Guid categoryId,
            string createdBy)
        {
            Validate(name, price, stock);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            IsActive = true;
            CreatedBy = createdBy;
        }

        public void Update(
            string name,
            string description,
            decimal price,
            int stock,
            string updatedBy)
        {
            Validate(name, price, stock);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;

            SetUpdated(updatedBy);
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(
                    "Cantidad debe ser mayor que 0.");
            }

            if (Stock < quantity)
            {
                throw new DomainException(
                    $"Stock insuficiente para el producto: {Name}.");
            }

            Stock -= quantity;
        }

        private void Validate(
            string name,
            decimal price,
            int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(
                    "Nombre del producto es requerido.");
            }

            if (price <= 0)
            {
                throw new DomainException(
                    "El precio debe ser mayor que 0.");
            }

            if (stock < 0)
            {
                throw new DomainException(
                    "Stock no puede ser negativo.");
            }
        }
    }
}
