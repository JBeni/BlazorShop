namespace BlazorShop.Application.Common.Models
{
    public class JwtTokenResponse
    {
        public string? Access_Token { get; set; }
        public string? Type => "Bearer";
        public int Expires_In { get; set; }

        public bool Successful { get; set; }
        public string? Error { get; set; }

        public static JwtTokenResponse Failure(string error)
        {
            return new JwtTokenResponse { Successful = false, Error = error };
        }
    }
}
