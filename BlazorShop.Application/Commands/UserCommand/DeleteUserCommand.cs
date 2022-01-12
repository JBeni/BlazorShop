namespace BlazorShop.Application.Commands.UserCommand
{
    public class DeleteUserCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
