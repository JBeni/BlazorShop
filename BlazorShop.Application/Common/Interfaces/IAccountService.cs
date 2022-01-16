namespace BlazorShop.Application.Common.Interfaces
{
    public interface IAccountService
    {
        Task<RequestResponse> ResetPasswordUserAsync(ResetPasswordCommand resetPassword);
        Task<RequestResponse> ChangePasswordUserAsync(ChangePasswordCommand changePassword);
        Task<JwtTokenResponse> GenerateToken(User user);
        Task<JwtTokenResponse> LoginAsync(LoginCommand login);
        Task<JwtTokenResponse> RegisterAsync(RegisterCommand register);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
