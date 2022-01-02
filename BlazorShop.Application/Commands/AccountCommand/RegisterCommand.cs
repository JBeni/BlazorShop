namespace BlazorShop.Application.Commands.AccountCommand
{
    public class RegisterCommand : IRequest<JwtTokenResponse>
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RoleName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
