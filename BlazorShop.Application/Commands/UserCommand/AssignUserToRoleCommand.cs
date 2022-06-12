namespace BlazorShop.Application.Commands.UserCommand
{
    public class AssignUserToRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int RoleId { get; set; }
    }
}
