namespace BlazorShop.Application.Commands.RoleCommand
{
    public class CreateRoleCommand : IRequest<RequestResponse>
    {
        public string? Name { get; set; }
    }
}
