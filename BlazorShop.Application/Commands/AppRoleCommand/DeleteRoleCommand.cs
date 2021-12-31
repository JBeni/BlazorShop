namespace BlazorShop.Application.Commands.AppRoleCommand
{
    public class DeleteRoleCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
