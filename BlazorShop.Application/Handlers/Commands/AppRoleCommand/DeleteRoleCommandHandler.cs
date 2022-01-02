namespace BlazorShop.Application.Handlers.Commands.AppRoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RequestResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RequestResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(request.Id.ToString());
                if (role == null) throw new Exception("The role was not created");

                await _roleManager.DeleteAsync(role);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}
