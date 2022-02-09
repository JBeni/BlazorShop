namespace BlazorShop.Application.Common.Models
{
    public class JwtTokenResponse
    {
        public string? Access_Token { get; set; } = null;
        public string? Type => "Bearer";
        public int Expires_In { get; set; }

        public bool Successful { get; set; } = false;
        public string? Error { get; set; } = null;

        public static JwtTokenResponse Failure(string error)
        {
            return new JwtTokenResponse { Error = error };
        }
    }
}
