namespace Zadanie8.Middleware
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            string userAgent = context.Request.Headers["User-Agent"].ToString();
            var keyWords = new[] { "MSIE", "Trident","Edg" };

            if (keyWords.Any(userAgent.Contains))
            {
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }
            return _next(context);
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}

