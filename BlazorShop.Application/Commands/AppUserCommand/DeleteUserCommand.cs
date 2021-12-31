namespace BlazorShop.Application.Commands.AppUserCommand
{
    public class DeleteUserCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
