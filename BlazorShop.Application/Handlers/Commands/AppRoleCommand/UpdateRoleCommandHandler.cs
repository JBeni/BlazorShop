namespace BlazorShop.Application.Handlers.Commands.AppRoleCommand
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public UpdateRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RequestResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existsRole = await _roleManager.RoleExistsAsync(request.Name);
                if (existsRole) throw new Exception("The new role already exists");

                var role = await _roleManager.FindByNameAsync(request.OldName);
                if (role == null) throw new Exception("The role was not created");

                role.Name = request.Name;
                role.NormalizedName = request.NormalizedName;

                await _roleManager.CreateAsync(role);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}
