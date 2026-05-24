using CatalogOrder.Application.Categories.DTOs;
using CatalogOrder.Application.Common.Interfaces;
using CatalogOrder.Application.Common.Models;
using CatalogOrder.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Categories.Services
{
    public class CategoryService
    {
        private readonly IAppDbContext _context;

        private readonly ICurrentUserService _currentUser;

        public CategoryService(
            IAppDbContext context,
            ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<ApiResponse<Guid>> CreateAsync(
            CreateCategoryDto dto)
        {
            var category = new Category(
                dto.Name,
                _currentUser.Username);

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return ApiResponse<Guid>.Ok(category.Id);
        }
    }
}
