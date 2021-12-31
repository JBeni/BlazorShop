namespace BlazorShop.Application.Commands.UserJwtTokenCommand
{
    public class DeleteUserJwtTokenCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
    }
}
