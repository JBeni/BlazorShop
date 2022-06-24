// <copyright file="UserService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IUserService"/>.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            IRoleService roleService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleService = roleService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> CreateUserAsync(CreateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.UserName == command.Email && u.IsActive == true);
            if (existUser != null) throw new Exception("The user with the unique identifier already exists");

            var newUser = new User
            {
                UserName = command.FirstName + "@" + command.LastName,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(newUser);
            if (command.Role.Length > 0)
            {
                await _userManager.AddToRoleAsync(newUser, command.Role);
            }

            var user = await _userManager.FindByEmailAsync(command.Email);
            return RequestResponse.Success(user.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteUserAsync(int userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId && u.IsActive == true);
            if (user == null) throw new Exception("The user doesn't exist");

            user.IsActive = false;

            var result = await _userManager.UpdateAsync(user);
            return RequestResponse.Success(user.Id);
        }

        /// <inheritdoc/>
        public async Task<User> FindUserByEmailAsync(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            return result;
        }

        /// <inheritdoc/>
        public async Task<User> FindUserByIdAsync(int userId)
        {
            var result = await _userManager.FindByIdAsync(userId.ToString());
            return result;
        }

        /// <inheritdoc/>
        public UserResponse GetUserById(GetUserByIdQuery query)
        {
            var user = _userManager.Users
                .TagWith(nameof(GetUserById))
                .Where(x => x.Id == query.Id && x.IsActive == true)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        /// <inheritdoc/>
        public UserResponse GetUserByEmail(GetUserByEmailQuery query)
        {
            var user = _userManager.Users
                .TagWith(nameof(GetUserByEmail))
                .Where(x => x.Email == query.Email && x.IsActive == true)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetUserRoleAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList();
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateUserAsync(UpdateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == command.Id && u.IsActive == true);
            if (existUser == null) throw new Exception("The user does not exists");

            existUser.UserName = command.FirstName + "@" + command.LastName;
            existUser.FirstName = command.FirstName;
            existUser.LastName = command.LastName;

            var result = await _userManager.UpdateAsync(existUser);

            if (command.Role != null)
            {
                var role = await _roleService.FindRoleByNameAsync(command.Role);
                await AssignUserToRoleAsync(new AssignUserToRoleCommand { UserId = existUser.Id, RoleId = role.Id });
            }
            return RequestResponse.Success(existUser.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ActivateUserAsync(ActivateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == command.Id);
            if (existUser == null) throw new Exception("The user does not exists");

            existUser.IsActive = true;

            var result = await _userManager.UpdateAsync(existUser);
            return RequestResponse.Success(existUser.Id);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == command.UserId &&
                u.Email == command.Email && u.IsActive == true);
            if (existUser == null) throw new Exception("The user does not exists");

            var userWithNewEmail = await _userManager.FindByEmailAsync(command.NewEmail);
            if (userWithNewEmail != null) throw new Exception("The user with the new email value has found in the database");

            existUser.Email = command.NewEmail;

            var result = await _userManager.UpdateAsync(existUser);
            return RequestResponse.Success(existUser.Id);
        }

        /// <inheritdoc/>
        public List<UserResponse> GetUsers(GetUsersQuery query)
        {
            var result = _userManager.Users
                .TagWith(nameof(GetUsers))
                .Where(u => u.IsActive == true)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public List<UserResponse> GetUsersInactive(GetUsersInactiveQuery query)
        {
            var result = _userManager.Users
                .TagWith(nameof(GetUsersInactive))
                .Where(u => u.IsActive == false)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand command)
        {
            var user = await _userManager.FindByIdAsync(command.UserId.ToString());
            var userRole = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRoleAsync(user, userRole[0]);

            var role = await _roleService.FindRoleByIdAsync(command.RoleId);
            await _userManager.AddToRoleAsync(user, role.Name);

            return RequestResponse.Success(user.Id);
        }
    }
}
