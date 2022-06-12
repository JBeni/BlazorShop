namespace BlazorShop.Application.Commands.RoleCommand
{
    public class DeleteRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
