using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string Username { get; }
    }
}
