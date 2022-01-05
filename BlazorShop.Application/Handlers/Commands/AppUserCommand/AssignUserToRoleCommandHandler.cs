namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;

        public AssignUserToRoleCommandHandler(IAppUserService AppUserService)
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
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}
