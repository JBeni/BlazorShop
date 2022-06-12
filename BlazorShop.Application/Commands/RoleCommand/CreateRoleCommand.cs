namespace BlazorShop.Application.Commands.RoleCommand
{
    public class CreateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }
    }
}
