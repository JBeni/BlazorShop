namespace BlazorShop.Application.Responses
{
    public class JwtTokenResponse
    {
        public string? Access_Token { get; set; }
        public string? Type => "Bearer";
        public int Expires_In { get; set; }

        public bool Successful { get; set; }
        public Exception? Exception { get; set; }

        public static JwtTokenResponse Error(Exception exception)
        {
            return new JwtTokenResponse { Successful = false, Exception = exception };
        }
    }
}
