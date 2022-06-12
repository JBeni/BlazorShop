namespace BlazorShop.Application.Commands.AccountCommand
{
    public class LoginCommand : IRequest<JwtTokenResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Password { get; set; }
    }
}
