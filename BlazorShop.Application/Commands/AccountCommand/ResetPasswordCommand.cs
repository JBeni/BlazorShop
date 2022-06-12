namespace BlazorShop.Application.Commands.AccountCommand
{
    public class ResetPasswordCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? NewPassword { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? NewConfirmPassword { get; set; }
    }
}
