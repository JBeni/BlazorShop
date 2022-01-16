namespace BlazorShop.Application.Handlers.Commands.UserCommand
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly IUserService _userService;

        public AssignUserToRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.AssignUserToRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while assigning the role to user", ex));
            }
        }
    }
}
