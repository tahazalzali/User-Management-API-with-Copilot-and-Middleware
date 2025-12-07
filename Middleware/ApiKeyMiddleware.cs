using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UserManagementApiDotNet.Middleware
{
    /// <summary>
    /// Middleware that enforces the presence of an API key in the X-Api-Key header
    /// for certain HTTP methods. If the header is missing or incorrect, the
    /// request is rejected with a 401 Unauthorized response.
    /// </summary>
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string ApiKey = "secretkey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Enforce API key only for modifying requests (POST, PUT, DELETE)
            if (HttpMethods.IsPost(context.Request.Method) ||
                HttpMethods.IsPut(context.Request.Method) ||
                HttpMethods.IsDelete(context.Request.Method))
            {
                if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey) ||
                    providedApiKey != ApiKey)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { message = "Unauthorized" });
                    return;
                }
            }
            await _next(context);
        }
    }
}