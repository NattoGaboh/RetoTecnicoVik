using CatalogOrder.Domain.Common;
using CatalogOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Domain.Entity
{
    public class AppUser : BaseEntity
    {
        public string Username { get; private set; }

        public string PasswordHash { get; private set; }

        public UserRole Role { get; private set; }

        private AppUser()
        {
        }

        public AppUser(
            string username,
            string passwordHash,
            UserRole role)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException(
                    "Nombre de Usuario es requerido.");
            }

            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
