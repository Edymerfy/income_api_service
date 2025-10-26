using System.Diagnostics;

namespace Services.Tax.Api.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            var elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            _logger.LogInformation(
                "Request [{Method}] {Path} executed in {ElapsedMilliseconds} s",
                context.Request.Method,
                context.Request.Path,
                elapsedSeconds
            );
        }
    }
}
