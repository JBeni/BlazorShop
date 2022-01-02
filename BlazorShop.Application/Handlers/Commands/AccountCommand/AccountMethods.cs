namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class AccountMethods
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AccountMethods(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<JwtTokenResponse> GenerateToken(AppUser user)
        {
            var jwtSettings = new JwtTokenConfig
            {
                Secret = _configuration["JwtToken:SecretKey"],
                Issuer = _configuration["JwtToken:Issuer"],
                Audience = _configuration["JwtToken:Audience"],

                //AccessToken = TimeSpan.Parse(_configuration["JwtToken:AccessTokenExpiration"]).Tostring?(),
                //RefreshToken = TimeSpan.Parse(_configuration["JwtToken:RefreshTokenExpiration"]).Tostring?()
            };
            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            var userRole = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, userRole[0]),
                new Claim("UserId", user.Id.ToString()),
            };

            var expiresIn = DateTime.Now.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return new JwtTokenResponse
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires_In = (int)(expiresIn - DateTime.Now).TotalMinutes,
                Successful = true
            };
        }
    }
}
