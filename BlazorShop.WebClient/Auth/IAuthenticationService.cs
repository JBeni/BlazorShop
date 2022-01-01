namespace Blazor.Server.Auth
{
    public interface IAuthenticationService
    {
        Task<JwAccessToken> Login(LoginCommand userForAuthenticatrion);
        Task<JwAccessToken> Register(RegisterCommand userForAuthenticatrion);
        Task Logout();
    }
}
