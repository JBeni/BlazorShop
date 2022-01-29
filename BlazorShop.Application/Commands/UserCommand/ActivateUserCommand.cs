namespace BlazorShop.Application.Commands.UserCommand
{
    public class ActivateUserCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}
