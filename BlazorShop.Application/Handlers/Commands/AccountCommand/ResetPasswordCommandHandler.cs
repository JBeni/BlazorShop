namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, RequestResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new Exception("The user does not exist");
                }
                if (!request.NewPassword.Equals(request.NewConfirmPassword))
                {
                    throw new Exception("Passwords do not match");
                }

                await _userManager.ResetPasswordAsync(user, request.TokenReset, request.NewPassword);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error resetting the password", ex));
            }
        }
    }
}
