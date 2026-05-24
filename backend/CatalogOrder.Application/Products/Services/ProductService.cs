using CatalogOrder.Application.Common.Interfaces;
using CatalogOrder.Application.Common.Models;
using CatalogOrder.Application.Products.DTOs;
using CatalogOrder.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CatalogOrder.Application.Products.Services
{
    public class ProductService
    {
        private readonly IAppDbContext _context;

        private readonly ICurrentUserService _currentUser;

        public ProductService(IAppDbContext context,ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<PagedResult<ProductDto>> GetPagedAsync(int page,int pageSize,string? search)
        {
            var query = _context.Products.Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            var total = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Stock = x.Stock,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            return new PagedResult<ProductDto>
            {
                Items = items,
                TotalCount = total,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<ApiResponse<Guid>> CreateAsync(CreateProductDto dto)
        {
            var product = new Product(
                dto.Name,
                dto.Description,
                dto.Price,
                dto.Stock,
                dto.CategoryId,
                _currentUser.Username);

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return ApiResponse<Guid>.Ok(product.Id);
        }
    }
}
