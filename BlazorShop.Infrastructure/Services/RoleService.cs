﻿namespace BlazorShop.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<string>> CheckUserRolesAsync(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public RoleResponse GetDefaultRole()
        {
            var role = _roleManager.Roles
                .Where(x => x.Name == "Default" && x.NormalizedName == "DEFAULT")
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        public RoleResponse GetUserRole()
        {
            var role = _roleManager.Roles
                .Where(x => x.Name == "User" && x.NormalizedName == "USER")
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        public RoleResponse GetAdminRole()
        {
            var role = _roleManager.Roles
                .Where(x => x.Name == "Admin" && x.NormalizedName == "ADMIN")
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        public async Task<RequestResponse> SetUserRoleAsync(AppUser user, string role)
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

        public List<RoleResponse> GetRoles()
        {
            var result = _roleManager.Roles
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public RoleResponse GetRoleById(int id)
        {
            var result = _roleManager.Roles
                .Where(_x => _x.Id == id)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public RoleResponse GetRoleByNormalizedName(string normalizedName)
        {
            var result = _roleManager.Roles
                .Where(_x => _x.NormalizedName == normalizedName)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public async Task<RequestResponse> CreateRoleAsync(CreateRoleCommand command)
        {
            var role = await _roleManager.FindByNameAsync(command.Name);
            if (role != null) throw new Exception("The role was already created");

            await _roleManager.CreateAsync(new AppRole
            {
                Name = command.Name,
                NormalizedName = command.Name.ToUpper()
            });

            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand command)
        {
            var existsRole = await _roleManager.RoleExistsAsync(command.NewName);
            if (existsRole) throw new Exception("The new role already exists");

            var role = await _roleManager.FindByNameAsync(command.OldName);
            if (role == null) throw new Exception("The role was not created");

            role.Name = command.NewName;
            role.NormalizedName = command.NewName.ToUpper();

            await _roleManager.CreateAsync(role);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteRoleAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) throw new Exception("The role was not found");

            await _roleManager.DeleteAsync(role);
            return RequestResponse.Success();
        }

        public async Task<AppRole> FindRoleByIdAsync(int roleId)
        {
            var result = await _roleManager.FindByIdAsync(roleId.ToString());
            return result;
        }

        public async Task<AppRole> FindRoleByNameAsync(string name)
        {
            var result = await _roleManager.FindByNameAsync(name);
            return result;
        }
    }
}