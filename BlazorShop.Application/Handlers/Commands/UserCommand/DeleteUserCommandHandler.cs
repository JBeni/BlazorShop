namespace BlazorShop.Application.Handlers.Commands.UserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while deleting the user", ex));
            }
        }
    }
}
