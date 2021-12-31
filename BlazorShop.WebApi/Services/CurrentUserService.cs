namespace BlazorShop.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId");
        public string? Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
    }
}
