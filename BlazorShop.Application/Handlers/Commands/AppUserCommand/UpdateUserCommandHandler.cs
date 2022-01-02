namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, RequestResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existUser = _userManager.Users.SingleOrDefault(u => u.Id == request.Id);
                if (existUser == null) throw new Exception("The user with the unique identifier already exists");

                var userWithNewEmail = await _userManager.FindByEmailAsync(request.NewEmail);
                if (userWithNewEmail != null) throw new Exception("The user with the new email value has found in the database");

                existUser.UserName = request.NewEmail;
                existUser.Email = request.NewEmail;
                existUser.FirstName = request.FirstName;
                existUser.LastName = request.LastName;

                await _userManager.UpdateAsync(existUser);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}
