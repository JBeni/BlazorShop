namespace BlazorShop.Application.Commands.AppRoleCommand
{
    public class CreateRoleCommand : IRequest<RequestResponse>
    {
        public string? Name { get; set; }
    }
}
