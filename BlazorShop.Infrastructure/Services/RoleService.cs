// <copyright file="RoleService.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IRoleService"/>.
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// .
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// .
        /// </summary>
        private readonly RoleManager<Role> _roleManager;

        /// <summary>
        /// .
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="mapper"></param>
        public RoleService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<string>> CheckUserRolesAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        /// <inheritdoc/>
        public RoleResponse GetDefaultRole()
        {
            var role = _roleManager.Roles
                .TagWith(nameof(GetDefaultRole))
                .Where(x => x.Name == StringRoleResources.Default &&
                    x.NormalizedName == StringRoleResources.DefaultNormalized)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        /// <inheritdoc/>
        public RoleResponse GetUserRole()
        {
            var role = _roleManager.Roles
                .TagWith(nameof(GetUserRole))
                .Where(x => x.Name == StringRoleResources.User &&
                    x.NormalizedName == StringRoleResources.UserNormalized)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        /// <inheritdoc/>
        public RoleResponse GetAdminRole()
        {
            var role = _roleManager.Roles
                .TagWith(nameof(GetAdminRole))
                .Where(x => x.Name == StringRoleResources.Admin &&
                    x.NormalizedName == StringRoleResources.AdminNormalized)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> SetUserRoleAsync(User user, string role)
        {
            var roles = await CheckUserRolesAsync(user);
            if (roles.Count == 0)
            {
                await _userManager.AddToRoleAsync(user, role);
                var roleData = await _roleManager.FindByNameAsync(role);
                return RequestResponse.Success(roleData.Id);
            }
            else if (roles.Count > 0)
            {
                await _userManager.RemoveFromRoleAsync(user, roles[0]);
                await _userManager.AddToRoleAsync(user, role);
                var roleData = await _roleManager.FindByNameAsync(role);
                return RequestResponse.Success(roleData.Id);
            }

            throw new Exception("The user has already a role");
        }

        /// <inheritdoc/>
        public List<RoleResponse> GetRoles()
        {
            var result = _roleManager.Roles
                .TagWith(nameof(GetRoles))
                .Where(x => x.Name != StringRoleResources.Admin &&
                    x.NormalizedName != StringRoleResources.AdminNormalized)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public List<RoleResponse> GetRolesForAdmin()
        {
            var result = _roleManager.Roles
                .TagWith(nameof(GetRolesForAdmin))
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public RoleResponse GetRoleById(int id)
        {
            var result = _roleManager.Roles
                .TagWith(nameof(GetRoleById))
                .Where(_x => _x.Id == id)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        /// <inheritdoc/>
        public RoleResponse GetRoleByNormalizedName(string normalizedName)
        {
            var result = _roleManager.Roles
                .TagWith(nameof(GetRoleByNormalizedName))
                .Where(_x => _x.NormalizedName == normalizedName)
                .ProjectTo<RoleResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> CreateRoleAsync(CreateRoleCommand command)
        {
            var role = await _roleManager.FindByNameAsync(command.Name);
            if (role != null) throw new Exception("The role was already created");

            await _roleManager.CreateAsync(new Role
            {
                Name = command.Name,
                NormalizedName = command.Name.ToUpper()
            });

            var roleData = await _roleManager.FindByNameAsync(command.Name);
            return RequestResponse.Success(roleData.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand command)
        {
            var existsRole = await _roleManager.FindByNameAsync(command.Name);
            if (existsRole != null) throw new Exception("The new role already exists");

            var role = await _roleManager.FindByIdAsync(command.Id.ToString());
            if (role == null) throw new Exception("The role was not created");

            role.Name = command.Name;
            role.NormalizedName = command.Name.ToUpper();

            await _roleManager.UpdateAsync(role);
            return RequestResponse.Success(role.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteRoleAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) throw new Exception("The role was not found");

            await _roleManager.DeleteAsync(role);
            return RequestResponse.Success(role.Id);
        }

        /// <inheritdoc/>
        public async Task<Role> FindRoleByIdAsync(int roleId)
        {
            var result = await _roleManager.FindByIdAsync(roleId.ToString());
            return result;
        }

        /// <inheritdoc/>
        public async Task<Role> FindRoleByNameAsync(string name)
        {
            var result = await _roleManager.FindByNameAsync(name);
            return result;
        }
    }
}
