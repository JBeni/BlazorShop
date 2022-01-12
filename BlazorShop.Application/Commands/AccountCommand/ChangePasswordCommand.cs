namespace BlazorShop.Application.Commands.AccountCommand
{
    public class ChangePasswordCommand : IRequest<RequestResponse>
    {
        public int UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
