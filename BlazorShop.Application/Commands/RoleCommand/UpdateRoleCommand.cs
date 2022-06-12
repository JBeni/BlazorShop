namespace BlazorShop.Application.Commands.RoleCommand
{
    public class UpdateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }
    }
}
