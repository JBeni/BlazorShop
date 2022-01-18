namespace BlazorShop.WebClient.Interfaces
{
    public interface IAccountService
    {
        Task<RequestResponse> ChangePassword(ChangePasswordCommand command);
        Task<RequestResponse> ResetPassword(ResetPasswordCommand command);
    }
}
