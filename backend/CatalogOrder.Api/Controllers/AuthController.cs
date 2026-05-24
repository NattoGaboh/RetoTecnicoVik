using CatalogOrder.Application.Auth.DTOs;
using CatalogOrder.Application.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOrder.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(
            AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequestDto request)
        {
            var result =
                await _authService.LoginAsync(request);

            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
