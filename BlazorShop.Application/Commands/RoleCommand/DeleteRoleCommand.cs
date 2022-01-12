namespace BlazorShop.Application.Commands.RoleCommand
{
    public class DeleteRoleCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
