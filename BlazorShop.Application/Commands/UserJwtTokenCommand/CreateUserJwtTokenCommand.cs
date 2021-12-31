namespace BlazorShop.Application.Commands.ProductCommand
{
    public class CreateUserJwtTokenCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
        public string? JwtToken { get; set; }
        public DateTime TokenTimestamp { get; set; }
    }
}
