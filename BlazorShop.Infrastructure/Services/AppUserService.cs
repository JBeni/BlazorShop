namespace BlazorShop.Infrastructure.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppRoleService _AppRoleService;
        private readonly IMapper _mapper;

        public AppUserService(
            UserManager<AppUser> userManager,
            IAppRoleService AppRoleService,
            IMapper mapper)
        {
            _userManager = userManager;
            _AppRoleService = AppRoleService;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateUserAsync(CreateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.UserName == command.Email);
            if (existUser != null) throw new Exception("The user with the unique identifier already exists");
            var newUser = new AppUser
            {
                UserName = command.Email,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
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
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null) throw new Exception("The user doesn't exist");

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

        public AppUserResponse GetUserById(GetUserByIdQuery query)
        {
            var user = _userManager.Users
                .Where(x => x.Id == query.Id)
                .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        public AppUserResponse GetUserByEmail(GetUserByEmailQuery query)
        {
            var user = _userManager.Users
                .Where(x => x.Email == query.Email)
                .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return user;
        }

        public async Task<AppUserResponse> GetUserRoleAsync(AppUser user)
        {
            var userWithRole = await _userManager.Users
                .Include(u => u.Roles)//.ThenInclude(ur => ur.Role)
                .Where(x => x.Email == user.Email && x.Id == user.Id)
                .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return userWithRole[0];
        }

        public async Task<RequestResponse> UpdateUserAsync(UpdateUserCommand command)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == command.Id);
            if (existUser == null) throw new Exception("The user with the unique identifier already exists");

            var userWithNewEmail = await _userManager.FindByEmailAsync(command.NewEmail);
            if (userWithNewEmail != null) throw new Exception("The user with the new email value has found in the database");

            existUser.UserName = command.NewEmail;
            existUser.Email = command.NewEmail;
            existUser.FirstName = command.FirstName;
            existUser.LastName = command.LastName;

            await _userManager.UpdateAsync(existUser);
            return RequestResponse.Success();
        }

        public List<AppUserResponse> GetUsers(GetUsersQuery query)
        {
            var result = _userManager.Users
                .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
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
