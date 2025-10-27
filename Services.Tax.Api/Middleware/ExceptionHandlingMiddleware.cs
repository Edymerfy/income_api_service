using Services.Tax.Domain.Api;

namespace Services.Tax.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                _logger.LogError(ex.Message);

                await context.Response.WriteAsJsonAsync(
                    GeneralResponse<object>.FailResponse("A server-side error occurred.", 500)
                );
            }
        }
    }

}
