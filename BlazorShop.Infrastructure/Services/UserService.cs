// <copyright file="UserService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IUserService"/>.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userManager">The instance of <see cref="UserManager{User}"/> to use.</param>
        /// <param name="roleService">The instance of <see cref="IRoleService"/> to use.</param>
        /// <param name="mapper">The instance of <see cref="IMapper"/> to use.</param>
        public UserService(
            UserManager<User> userManager,
            IRoleService roleService,
            IMapper mapper)
        {
            this.UserManager = userManager;
            this.RoleService = roleService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IRoleService"/> to use.
        /// </summary>
        private IRoleService RoleService { get; }

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; }

        /// <inheritdoc/>
        public async Task<RequestResponse> CreateUserAsync(CreateUserCommand command)
        {
            var existUser = this.UserManager.Users.SingleOrDefault(u => u.UserName == command.Email && u.IsActive == true);
            if (existUser != null)
            {
                throw new Exception("The user with the unique identifier already exists");
            }

            var newUser = new User
            {
                UserName = command.FirstName + "@" + command.LastName,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsActive = true,
            };

            var result = await this.UserManager.CreateAsync(newUser);
            if (command.Role.Length > 0)
            {
                await this.UserManager.AddToRoleAsync(newUser, command.Role);
            }

            var user = await this.UserManager.FindByEmailAsync(command.Email);
            return RequestResponse.Success(user.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteUserAsync(int userId)
        {
            var user = this.UserManager.Users.SingleOrDefault(u => u.Id == userId && u.IsActive == true);
            if (user == null)
            {
                throw new Exception("The user doesn't exist");
            }

            user.IsActive = false;

            var result = await this.UserManager.UpdateAsync(user);
            return RequestResponse.Success(user.Id);
        }

        /// <inheritdoc/>
        public async Task<User> FindUserByEmailAsync(string email)
        {
            var result = await this.UserManager.FindByEmailAsync(email);
            return result;
        }

        /// <inheritdoc/>
        public async Task<User> FindUserByIdAsync(int userId)
        {
            var result = await this.UserManager.FindByIdAsync(userId.ToString());
            return result;
        }

        /// <inheritdoc/>
        public UserResponse GetUserById(GetUserByIdQuery query)
        {
            var user = this.UserManager.Users
                .TagWith(nameof(this.GetUserById))
                .Where(x => x.Id == query.Id && x.IsActive == true)
                .ProjectTo<UserResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        /// <inheritdoc/>
        public UserResponse GetUserByEmail(GetUserByEmailQuery query)
        {
            var user = this.UserManager.Users
                .TagWith(nameof(this.GetUserByEmail))
                .Where(x => x.Email == query.Email && x.IsActive == true)
                .ProjectTo<UserResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetUserRoleAsync(User user)
        {
            var userRoles = await this.UserManager.GetRolesAsync(user);
            return userRoles.ToList();
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateUserAsync(UpdateUserCommand command)
        {
            var existUser = this.UserManager.Users.SingleOrDefault(u => u.Id == command.Id && u.IsActive == true);
            if (existUser == null)
            {
                throw new Exception("The user does not exists");
            }

            existUser.UserName = command.FirstName + "@" + command.LastName;
            existUser.FirstName = command.FirstName;
            existUser.LastName = command.LastName;

            var result = await this.UserManager.UpdateAsync(existUser);

            if (command.Role != null)
            {
                var role = await this.RoleService.FindRoleByNameAsync(command.Role);
                await this.AssignUserToRoleAsync(new AssignUserToRoleCommand { UserId = existUser.Id, RoleId = role.Id });
            }

            return RequestResponse.Success(existUser.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ActivateUserAsync(ActivateUserCommand command)
        {
            var existUser = this.UserManager.Users.SingleOrDefault(u => u.Id == command.Id);
            if (existUser == null)
            {
                throw new Exception("The user does not exists");
            }

            existUser.IsActive = true;

            var result = await this.UserManager.UpdateAsync(existUser);
            return RequestResponse.Success(existUser.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand command)
        {
            var existUser = this.UserManager.Users.SingleOrDefault(u => u.Id == command.UserId &&
                u.Email == command.Email && u.IsActive == true);
            if (existUser == null)
            {
                throw new Exception("The user does not exists");
            }

            var userWithNewEmail = await this.UserManager.FindByEmailAsync(command.NewEmail);
            if (userWithNewEmail != null)
            {
                throw new Exception("The user with the new email value has found in the database");
            }

            existUser.Email = command.NewEmail;

            var result = await this.UserManager.UpdateAsync(existUser);
            return RequestResponse.Success(existUser.Id);
        }

        /// <inheritdoc/>
        public List<UserResponse> GetUsers(GetUsersQuery query)
        {
            var result = this.UserManager.Users
                .TagWith(nameof(this.GetUsers))
                .Where(u => u.IsActive == true)
                .ProjectTo<UserResponse>(this.Mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public List<UserResponse> GetUsersInactive(GetUsersInactiveQuery query)
        {
            var result = this.UserManager.Users
                .TagWith(nameof(this.GetUsersInactive))
                .Where(u => u.IsActive == false)
                .ProjectTo<UserResponse>(this.Mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand command)
        {
            var user = await this.UserManager.FindByIdAsync(command.UserId.ToString());
            var userRole = await this.UserManager.GetRolesAsync(user);
            await this.UserManager.RemoveFromRoleAsync(user, userRole[0]);

            var role = await this.RoleService.FindRoleByIdAsync(command.RoleId);
            await this.UserManager.AddToRoleAsync(user, role.Name);

            return RequestResponse.Success(user.Id);
        }
    }
}
