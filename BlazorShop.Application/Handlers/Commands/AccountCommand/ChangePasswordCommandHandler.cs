namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RequestResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public ChangePasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new Exception("The user does not exist");
                }
                if (!await _userManager.CheckPasswordAsync(user, request.OldPassword))
                {
                    throw new Exception("The credential is not valid");
                }
                if (!request.NewPassword.Equals(request.NewConfirmPassword))
                {
                    throw new Exception("Passwords do not match");
                }

                await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error changing the password", ex));
            }
        }
    }
}
