namespace OrderProcessingServices.Middleware
{
    public class InternalApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        private const string HEADER_NAME = "x-internal-key";

        public InternalApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,IConfiguration configuration)
        {
            if (!context.Request.Headers.TryGetValue(HEADER_NAME, out var extractedKey))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync("Internal API Key missing.");

                return;
            }

            var apiKey = configuration["InternalService:ApiKey"];

            if (!apiKey!.Equals(extractedKey))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync("Invalid Internal API Key.");

                return;
            }

            await _next(context);
        }
    }
}
