namespace BlazorShop.Application.Commands.UserCommand
{
    public class AssignUserToRoleCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
