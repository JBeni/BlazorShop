namespace BlazorShop.Application.Commands.AppUserCommand
{
    public class AssignUserToRoleCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
