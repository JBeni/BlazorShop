namespace BlazorShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IRoleService _AppRoleService;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IRoleService AppRoleService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _AppRoleService = AppRoleService;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateUserAsync(CreateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.UserName == command.Email && u.IsActive == true);
            if (existUser != null) throw new Exception("The user with the unique identifier already exists");
            var newUser = new AppUser
            {
                UserName = command.FirstName + "@" + command.LastName,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsActive = true
            };

            await _userManager.CreateAsync(newUser);
            if (command.Role.Length > 0)
            {
                await _userManager.AddToRoleAsync(newUser, command.Role);
            }

            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteUserAsync(int userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId && u.IsActive == true);
            if (user == null) throw new Exception("The user doesn't exist");

            user.IsActive = false;

            await _userManager.UpdateAsync(user);
            return RequestResponse.Success();
        }

        public async Task<AppUser> FindUserByEmailAsync(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            return result;
        }

        public async Task<AppUser> FindUserByIdAsync(int userId)
        {
            var result = await _userManager.FindByIdAsync(userId.ToString());
            return result;
        }

        public UserResponse GetUserById(GetUserByIdQuery query)
        {
            var user = _userManager.Users
                .Where(x => x.Id == query.Id && x.IsActive == true)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        public UserResponse GetUserByEmail(GetUserByEmailQuery query)
        {
            var user = _userManager.Users
                .Where(x => x.Email == query.Email && x.IsActive == true)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        public async Task<List<string>> GetUserRoleAsync(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            //var userWithRole = await _userManager.Users
            //    .Include(u => u.Roles)
            //    .Where(x => x.Email == user.Email && x.Id == user.Id)
            //    .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
            //    .ToListAsync();
            return userRoles.ToList();
        }

        public async Task<RequestResponse> UpdateUserAsync(UpdateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == command.Id && u.IsActive == true);
            if (existUser == null) throw new Exception("The user does not exists");

            existUser.UserName = command.FirstName + "@" + command.LastName;
            existUser.FirstName = command.FirstName;
            existUser.LastName = command.LastName;

            await _userManager.UpdateAsync(existUser);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == command.UserId && u.Email == command.Email && u.IsActive == true);
            if (existUser == null) throw new Exception("The user does not exists");

            var userWithNewEmail = await _userManager.FindByEmailAsync(command.NewEmail);
            if (userWithNewEmail != null) throw new Exception("The user with the new email value has found in the database");

            existUser.Email = command.NewEmail;

            await _userManager.UpdateAsync(existUser);
            return RequestResponse.Success();
        }

        public List<UserResponse> GetUsers(GetUsersQuery query)
        {
            var result = _userManager.Users
                .Where(u => u.IsActive == true)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand command)
        {
            var user = await _userManager.FindByIdAsync(command.UserId.ToString());
            var userRole = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRoleAsync(user, userRole[0]);

            var role = await _AppRoleService.FindRoleByIdAsync(command.RoleId);
            await _userManager.AddToRoleAsync(user, role.Name);
            return RequestResponse.Success();
        }
    }
}
