// <copyright file="AccountService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IAccountService"/>.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ChangePasswordUserAsync(ChangePasswordCommand changePassword)
        {
            var user = await _userManager.FindByIdAsync(changePassword.UserId.ToString());
            if (user == null) throw new Exception("The user does not exist");

            if (!await _userManager.CheckPasswordAsync(user, changePassword.OldPassword))
                throw new Exception("The credentials are not valid");

            if (!changePassword.NewPassword.Equals(changePassword.ConfirmNewPassword))
                throw new Exception("Passwords do not match");

            await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
            return RequestResponse.Success();
        }

        /// <inheritdoc/>
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        /// <inheritdoc/>
        public async Task<JwtTokenResponse> GenerateToken(User user)
        {
            var jwtSettings = new JwtTokenConfig
            {
                Secret = _configuration["JwtToken:SecretKey"],
                Issuer = _configuration["JwtToken:Issuer"],
                Audience = _configuration["JwtToken:Audience"],
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));

            var userRole = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, userRole[0]),
                new Claim(StringRoleResources.UserIdClaim, user.Id.ToString()),
            };

            var expiresIn = DateTime.Now.AddSeconds(20);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return new JwtTokenResponse
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires_In = (int)(expiresIn - DateTime.Now).TotalSeconds,
                Successful = true
            };
        }

        /// <inheritdoc/>
        public async Task<JwtTokenResponse> LoginAsync(LoginCommand login)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == login.Email);
            if (user == null) throw new Exception("Email / password incorrect");

            var passwordValid = await CheckPasswordAsync(user, login.Password);
            if (passwordValid == false) throw new Exception("Email / password incorrect");

            return await GenerateToken(user);
        }

        /// <inheritdoc/>
        public async Task<JwtTokenResponse> RegisterAsync(RegisterCommand register)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.Email == register.Email);
            if (existUser != null) throw new Exception("The user with the unique identifier already exists");

            var newUser = new User
            {
                UserName = register.FirstName + "@" + register.LastName,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                IsActive = true,
            };
            if (!register.Password.Equals(register.ConfirmPassword))
                throw new Exception("Passwords do not match");

            await _userManager.CreateAsync(newUser, register.Password);

            var role = await _roleManager.FindByNameAsync(StringRoleResources.Default);
            if (role == null) throw new Exception("The role does not exist");

            await _userManager.AddToRoleAsync(newUser, role.Name);
            return await GenerateToken(newUser);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ResetPasswordUserAsync(ResetPasswordCommand resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null) throw new Exception("The user does not exist");
            
            if (!resetPassword.NewPassword.Equals(resetPassword.NewConfirmPassword))
                throw new Exception("Passwords do not match");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
            return RequestResponse.Success();
        }
    }
}
