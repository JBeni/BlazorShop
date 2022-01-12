namespace BlazorShop.Application.Handlers.Commands.UserCommand
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly IUserService _AppUserService;

        public AssignUserToRoleCommandHandler(IUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppUserService.AssignUserToRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while assigning the role to user", ex));
            }
        }
    }
}
