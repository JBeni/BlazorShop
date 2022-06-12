namespace BlazorShop.WebApi.Filters
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var user = context.User.Identity.Name;
            var role = context.User.IsInRole(StringRoleResources.Admin);

            await _next(context);
        }
    }
}
