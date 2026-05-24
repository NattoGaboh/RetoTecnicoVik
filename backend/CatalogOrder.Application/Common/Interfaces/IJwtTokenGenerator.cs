using CatalogOrder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(AppUser user);
    }
}
