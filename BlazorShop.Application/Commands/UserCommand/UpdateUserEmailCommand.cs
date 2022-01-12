namespace BlazorShop.Application.Commands.UserCommand
{
    public class UpdateUserEmailCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? NewEmail { get; set; }
    }
}
