using CatalogOrder.Application.Auth.DTOs;
using CatalogOrder.Application.Common.Interfaces;
using CatalogOrder.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrder.Application.Auth.Services
{
    public class AuthService
    {
        private readonly IAppDbContext _context;

        private readonly IJwtTokenGenerator _jwt;

        public AuthService(IAppDbContext context,IJwtTokenGenerator jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(
            LoginRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
                    x.Username == request.Username);

            if (user is null)
            {
                return ApiResponse<LoginResponseDto>.Fail("Credenciales inválidas.");
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!validPassword)
            {
                return ApiResponse<LoginResponseDto>.Fail("Credenciales inválidas.");
            }

            var token = _jwt.GenerateToken(user);

            return ApiResponse<LoginResponseDto>.Ok(
                new LoginResponseDto
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role.ToString()
                });
        }
    }
}
