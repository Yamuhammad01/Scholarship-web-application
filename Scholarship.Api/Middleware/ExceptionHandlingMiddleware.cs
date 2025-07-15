using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

/*namespace Scholarship.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Proceed to next middleware or controller
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

       /* private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "An unexpected error occurred.";

            // Customize known exception types
            if (exception is KeyNotFoundException && exception.Message.Contains("Biodata"))
            {
                statusCode = (int)HttpStatusCode.NotFound;
                message = exception.Message; // or hardcoded like: "Biodata with ID 2 not found."
            }

            var result = JsonSerializer.Serialize(new { message });
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
*/
