namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, JwtTokenResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AccountMethods _accountMethods;

        public RegisterCommandHandler(UserManager<AppUser> userManager,
                                      AccountMethods accountMethods,
                                      RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _accountMethods = accountMethods;
            _roleManager = roleManager;
        }

        public async Task<JwtTokenResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existUser = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);
                if (existUser != null) throw new Exception("The user with the unique identifier already exists");

                AppUser newUser = new AppUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                };

                if (!request.Password.Equals(request.ConfirmPassword))
                {
                    throw new Exception("Passwords do not match");
                }

                await _userManager.CreateAsync(newUser, request.Password);

                var role = await _roleManager.FindByNameAsync(request.RoleName);
                await _userManager.AddToRoleAsync(newUser, role.Name);
                return await _accountMethods.GenerateToken(newUser);
            }
            catch (Exception ex)
            {
                return JwtTokenResponse.Error(new Exception("There was an error register the user", ex));
            }
        }
    }
}
