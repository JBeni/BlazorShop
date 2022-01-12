namespace BlazorShop.Application.Commands.RoleCommand
{
    public class UpdateRoleCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
