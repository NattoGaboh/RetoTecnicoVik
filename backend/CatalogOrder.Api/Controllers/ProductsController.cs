using CatalogOrder.Application.Products.DTOs;
using CatalogOrder.Application.Products.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOrder.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged(int page = 1, int pageSize = 10, string? search = null)
        {
            var result =  await _service.GetPagedAsync(page,
                    pageSize,
                    search);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(
            CreateProductDto dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return Ok(result);
        }
    }
}
