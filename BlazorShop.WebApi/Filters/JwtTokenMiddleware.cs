namespace BlazorShop.WebApi.Filters
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var user = context.User.Identity.Name;
            var role = context.User.IsInRole("Admin");

            await _next(context);
        }
    }
}
