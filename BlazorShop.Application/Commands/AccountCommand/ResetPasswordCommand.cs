namespace BlazorShop.Application.Commands.AccountCommand
{
    public class ResetPasswordCommand : IRequest<RequestResponse>
    {
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
        public string? NewConfirmPassword { get; set; }
    }
}
