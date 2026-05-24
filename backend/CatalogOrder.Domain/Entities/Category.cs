using CatalogOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Domain.Entity
{
    public class Category : AuditableEntity
    {
        public string Name { get; private set; }

        public bool IsActive { get; private set; }

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private Category()
        {
        }

        public Category(string name, string createdBy)
        {
            ValidateName(name);

            Name = name;
            IsActive = true;
            CreatedBy = createdBy;
        }

        public void Update(string name, string updatedBy)
        {
            ValidateName(name);

            Name = name;

            SetUpdated(updatedBy);
        }

        public void Deactivate()
        {
            if (Products.Any(p => p.IsActive))
            {
                throw new DomainException(
                    "No se puede desactivar categoría con productos activos.");
            }

            IsActive = false;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Nombre de categoría es requerido.");
            }

            if (name.Length > 100)
            {
                throw new DomainException(
                    "Nombre de categoría no debe exceder los 100 caracteres.");
            }
        }
    }

}