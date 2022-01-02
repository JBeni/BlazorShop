namespace BlazorShop.WebClient.Auth
{
    public interface IAuthenticationService
    {
        Task<JwtAccessToken> Login(LoginCommand userForAuthenticatrion);
        Task<JwtAccessToken> Register(RegisterCommand userForAuthenticatrion);
        Task Logout();
    }
}
