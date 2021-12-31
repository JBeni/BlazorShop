namespace BlazorShop.Infrastructure.Services
{
    public class AppRoleService : IAppRoleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public AppRoleService(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<string?>> CheckUserRolesAsync(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public AppRoleResponse GetDefaultRole()
        {
            var role = _roleManager.Roles
                .Where(x => x.Name == "Default" && x.NormalizedName == "DEFAULT")
                .ProjectTo<AppRoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        public AppRoleResponse GetAdminRole()
        {
            var role = _roleManager.Roles
                .Where(x => x.Name == "Admin" && x.NormalizedName == "ADMIN")
                .ProjectTo<AppRoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        public async Task<RequestResponse> SetUserRoleAsync(AppUser user, string? role)
        {
            var roles = await CheckUserRolesAsync(user);
            if (roles.Count == 0)
            {
                await _userManager.AddToRoleAsync(user, role);
                return RequestResponse.Success();
            }
            else if (roles.Count > 0)
            {
                await _userManager.RemoveFromRoleAsync(user, roles[0]);
                await _userManager.AddToRoleAsync(user, role);
                return RequestResponse.Success();
            }

            throw new Exception("The user has already a role");
        }
    }
}
