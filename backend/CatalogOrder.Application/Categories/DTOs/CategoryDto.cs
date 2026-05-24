using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Categories.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
