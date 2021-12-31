namespace BlazorShop.Application.Commands.AccountCommand
{
    public class LoginCommand : IRequest<JwtTokenResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
