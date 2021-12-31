namespace BlazorShop.Application.Commands.AccountCommand
{
    public class ChangePasswordCommand : IRequest<RequestResponse>
    {
        public string? Email { get; set; }

        public string? UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? NewConfirmPassword { get; set; }
    }
}
