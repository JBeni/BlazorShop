namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, RequestResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userManager.Users.SingleOrDefault(u => u.Id == request.Id);
                if (user == null) throw new Exception("The user doesn't exist");

                await _userManager.UpdateAsync(user);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while deleting the user", ex));
            }
        }
    }
}
