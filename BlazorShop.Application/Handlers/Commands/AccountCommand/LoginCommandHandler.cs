namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AccountMethods _accountMethods;

        public LoginCommandHandler(UserManager<AppUser> userManager, AccountMethods accountMethods)
        {
            _userManager = userManager;
            _accountMethods = accountMethods;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string? password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task<JwtTokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("Email / password incorrect");
                }
                var passwordValid = await CheckPasswordAsync(user, request.Password);
                if (passwordValid == false)
                {
                    throw new Exception("Email / password incorrect");
                }

                return await _accountMethods.GenerateToken(user);
            }
            catch (Exception ex)
            {
                return JwtTokenResponse.Error(new Exception("There was an error login the user", ex));
            }
        }
    }
}
