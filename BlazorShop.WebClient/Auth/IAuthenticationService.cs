namespace BlazorShop.WebClient.Auth
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<JwtTokenResponse> Login(LoginCommand userForAuthenticatrion);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<JwtTokenResponse> Register(RegisterCommand userForAuthenticatrion);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task Logout();
    }
}
