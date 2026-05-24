using CatalogOrder.Domain.Common;
using System.Net;

namespace CatalogOrder.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        error = ex.Message
                    });
            }
            catch (Exception)
            {
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        error = "Internal server error."
                    });
            }
        }
    }
}
