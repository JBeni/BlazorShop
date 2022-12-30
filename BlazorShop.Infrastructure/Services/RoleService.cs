// <copyright file="RoleService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="userManager">The instance of <see cref="UserManager{User}"/> to use.</param>
        /// <param name="roleManager">The instance of <see cref="RoleManager{Role}"/> to use.</param>
        /// <param name="mapper">The instance of <see cref="IMapper"/> to use.</param>
        public RoleService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="RoleManager{Role}"/> to use.
        /// </summary>
        private RoleManager<Role> RoleManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; }

        /// <inheritdoc/>
        public async Task<List<string>> CheckUserRolesAsync(User user)
        {
            var roles = await this.UserManager.GetRolesAsync(user);
            return roles.ToList();
        }

        /// <inheritdoc/>
        public RoleResponse GetDefaultRole()
        {
            var role = this.RoleManager.Roles
                .TagWith(nameof(this.GetDefaultRole))
                .Where(x => x.Name == StringRoleResources.Default &&
                    x.NormalizedName == StringRoleResources.DefaultNormalized)
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        /// <inheritdoc/>
        public RoleResponse GetUserRole()
        {
            var role = this.RoleManager.Roles
                .TagWith(nameof(this.GetUserRole))
                .Where(x => x.Name == StringRoleResources.User &&
                    x.NormalizedName == StringRoleResources.UserNormalized)
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        /// <inheritdoc/>
        public RoleResponse GetAdminRole()
        {
            var role = this.RoleManager.Roles
                .TagWith(nameof(this.GetAdminRole))
                .Where(x => x.Name == StringRoleResources.Admin &&
                    x.NormalizedName == StringRoleResources.AdminNormalized)
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return role;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> SetUserRoleAsync(User user, string role)
        {
            var roles = await this.CheckUserRolesAsync(user);
            if (roles.Count == 0)
            {
                await this.UserManager.AddToRoleAsync(user, role);
                var roleData = await this.RoleManager.FindByNameAsync(role);
                return RequestResponse.Success(roleData.Id);
            }
            else if (roles.Count > 0)
            {
                await this.UserManager.RemoveFromRoleAsync(user, roles[0]);
                await this.UserManager.AddToRoleAsync(user, role);
                var roleData = await this.RoleManager.FindByNameAsync(role);
                return RequestResponse.Success(roleData.Id);
            }

            throw new Exception("The user has already a role");
        }

        /// <inheritdoc/>
        public List<RoleResponse> GetRoles()
        {
            var result = this.RoleManager.Roles
                .TagWith(nameof(this.GetRoles))
                .Where(x => x.Name != StringRoleResources.Admin &&
                    x.NormalizedName != StringRoleResources.AdminNormalized)
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public List<RoleResponse> GetRolesForAdmin()
        {
            var result = this.RoleManager.Roles
                .TagWith(nameof(this.GetRolesForAdmin))
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public RoleResponse GetRoleById(int id)
        {
            var result = this.RoleManager.Roles
                .TagWith(nameof(this.GetRoleById))
                .Where(x => x.Id == id)
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        /// <inheritdoc/>
        public RoleResponse GetRoleByNormalizedName(string normalizedName)
        {
            var result = this.RoleManager.Roles
                .TagWith(nameof(this.GetRoleByNormalizedName))
                .Where(x => x.NormalizedName == normalizedName)
                .ProjectTo<RoleResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> CreateRoleAsync(CreateRoleCommand command)
        {
            var role = await this.RoleManager.FindByNameAsync(command.Name);
            if (role != null)
            {
                throw new Exception("The role was already created");
            }

            await this.RoleManager.CreateAsync(new Role
            {
                Name = command.Name,
                NormalizedName = command.Name.ToUpper(),
            });

            var roleData = await this.RoleManager.FindByNameAsync(command.Name);
            return RequestResponse.Success(roleData.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand command)
        {
            var existsRole = await this.RoleManager.FindByNameAsync(command.Name);
            if (existsRole != null)
            {
                throw new Exception("The new role already exists");
            }

            var role = await this.RoleManager.FindByIdAsync(command.Id.ToString());
            if (role == null)
            {
                throw new Exception("The role was not created");
            }

            role.Name = command.Name;
            role.NormalizedName = command.Name.ToUpper();

            await this.RoleManager.UpdateAsync(role);
            return RequestResponse.Success(role.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteRoleAsync(int roleId)
        {
            var role = await this.RoleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                throw new Exception("The role was not found");
            }

            await this.RoleManager.DeleteAsync(role);
            return RequestResponse.Success(role.Id);
        }

        /// <inheritdoc/>
        public async Task<Role> FindRoleByIdAsync(int roleId)
        {
            var result = await this.RoleManager.FindByIdAsync(roleId.ToString());
            return result;
        }

        /// <inheritdoc/>
        public async Task<Role> FindRoleByNameAsync(string name)
        {
            var result = await this.RoleManager.FindByNameAsync(name);
            return result;
        }
    }
}
