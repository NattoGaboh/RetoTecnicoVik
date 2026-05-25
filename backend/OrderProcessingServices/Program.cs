using CatalogOrder.Infrastructure;
using CatalogOrder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using OrderProcessingServices.Middleware;
using OrderProcessingServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<OrderProcessingService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseMiddleware<InternalApiKeyMiddleware>();

app.MapControllers();

app.Run();
