namespace BlazorShop.WebClient.Auth
{
    public interface IAuthenticationService
    {
        Task<JwtTokenResponse> Login(LoginCommand userForAuthenticatrion);
        Task<JwtTokenResponse> Register(RegisterCommand userForAuthenticatrion);
        Task Logout();
    }
}
