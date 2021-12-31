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

        public async Task<RequestResponse> CreateUserAsync(CreateUserCommand user)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.UserName == user.Email);
            if (existUser == null)
            {
                var newUser = new AppUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };

                await _userManager.CreateAsync(newUser);
                if (user.Role.Length > 0)
                {
                    await _AppRoleService.SetUserRoleAsync(newUser, user.Role);
                }
                else
                {
                    var role = _AppRoleService.GetDefaultRole();
                    await _AppRoleService.SetUserRoleAsync(newUser, role.Name);
                }
                return RequestResponse.Success();
            }
            else
            {
                throw new Exception("The user with the unique identifier already exists");
            }
        }

        public async Task<RequestResponse> DeleteUserAsync(int userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            if (user != null)
            {
                await _userManager.UpdateAsync(user);
                return RequestResponse.Success();
            }
            else
            {
                throw new Exception("The user doesn't exist");
            }
        }

        public async Task<AppUser> FindUserByEmailAsync(string? email)
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

        public async Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Id == user.Id);
            if (existUser != null)
            {
                var userWithNewEmail = await _userManager.FindByEmailAsync(user.NewEmail);
                if (userWithNewEmail == null)
                {
                    existUser.UserName = user.NewEmail;
                    existUser.Email = user.NewEmail;
                    existUser.FirstName = user.FirstName;
                    existUser.LastName = user.LastName;

                    await _userManager.UpdateAsync(existUser);

                    return RequestResponse.Success();
                }
                else
                {
                    throw new Exception("The user with the new email value has found in the database");
                }
            }
            else
            {
                throw new Exception("The user with the unique identifier already exists");
            }
        }
    }
}
