using System.Diagnostics;

namespace DotNetCourseraFinal.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await _next(context);
            sw.Stop();

            Console.WriteLine($"[{context.Request.Method}] {context.Request.Path} took {sw.ElapsedMilliseconds} ms");
        }
    }
}
