using CatalogOrder.Application.Common.Interfaces;
using System.Security.Claims;

namespace CatalogOrder.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Username =>
            _httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Name)
            ?? "system";
    }
}
