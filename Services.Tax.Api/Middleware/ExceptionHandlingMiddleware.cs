using Services.Tax.Domain.Api;

namespace Services.Tax.Api.Middleware
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
                await _next(context);
            }
            catch
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync(
                    GeneralResponse<object>.FailResponse("A server-side error occurred.", 500)
                );
            }
        }
    }

}
