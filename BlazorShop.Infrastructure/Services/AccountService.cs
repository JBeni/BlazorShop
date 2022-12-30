// <copyright file="AccountService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IAccountService"/>.
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="userManager">The instance of <see cref="UserManager{User}"/> to use.</param>
        /// <param name="roleManager">The instance of <see cref="RoleManager{Role}"/> to use.</param>
        /// <param name="configuration">The instance of <see cref="IConfiguration"/> to use.</param>
        public AccountService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="RoleManager{Role}"/> to use.
        /// </summary>
        private RoleManager<Role> RoleManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public async Task<RequestResponse> ChangePasswordUserAsync(ChangePasswordCommand changePassword)
        {
            var user = await this.UserManager.FindByIdAsync(changePassword.UserId.ToString());
            if (user == null)
            {
                throw new Exception("The user does not exist");
            }

            if (!await this.UserManager.CheckPasswordAsync(user, changePassword.OldPassword))
            {
                throw new Exception("The credentials are not valid");
            }

            if (!changePassword.NewPassword.Equals(changePassword.ConfirmNewPassword))
            {
                throw new Exception("Passwords do not match");
            }

            await this.UserManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
            return RequestResponse.Success();
        }

        /// <inheritdoc/>
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result = await this.UserManager.CheckPasswordAsync(user, password);
            return result;
        }

        /// <inheritdoc/>
        public async Task<JwtTokenResponse> GenerateToken(User user)
        {
            var jwtSettings = new JwtTokenConfig
            {
                Secret = this.Configuration["JwtToken:SecretKey"],
                Issuer = this.Configuration["JwtToken:Issuer"],
                Audience = this.Configuration["JwtToken:Audience"],
            };
            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(jwtSettings.Secret));

            var userRole = await this.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, userRole[0]),
                new Claim(StringRoleResources.UserIdClaim, user.Id.ToString()),
            };

            var expiresIn = DateTime.Now.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return new JwtTokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = (int)(expiresIn - DateTime.Now).TotalSeconds,
                Successful = true,
            };
        }

        /// <inheritdoc/>
        public async Task<JwtTokenResponse> LoginAsync(LoginCommand login)
        {
            var user = this.UserManager.Users.SingleOrDefault(u => u.Email == login.Email);
            if (user == null)
            {
                throw new Exception("Email / password incorrect");
            }

            var passwordValid = await this.CheckPasswordAsync(user, login.Password);
            if (passwordValid == false)
            {
                throw new Exception("Email / password incorrect");
            }

            return await this.GenerateToken(user);
        }

        /// <inheritdoc/>
        public async Task<JwtTokenResponse> RegisterAsync(RegisterCommand register)
        {
            var existUser = this.UserManager.Users.SingleOrDefault(u => u.Email == register.Email);
            if (existUser != null)
            {
                throw new Exception("The user with the unique identifier already exists");
            }

            var newUser = new User
            {
                UserName = register.FirstName + "@" + register.LastName,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                IsActive = true,
            };
            if (!register.Password.Equals(register.ConfirmPassword))
            {
                throw new Exception("Passwords do not match");
            }

            await this.UserManager.CreateAsync(newUser, register.Password);

            var role = await this.RoleManager.FindByNameAsync(StringRoleResources.Default);
            if (role == null)
            {
                throw new Exception("The role does not exist");
            }

            await this.UserManager.AddToRoleAsync(newUser, role.Name);
            return await this.GenerateToken(newUser);
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ResetPasswordUserAsync(ResetPasswordCommand resetPassword)
        {
            var user = await this.UserManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                throw new Exception("The user does not exist");
            }

            if (!resetPassword.NewPassword.Equals(resetPassword.NewConfirmPassword))
            {
                throw new Exception("Passwords do not match");
            }

            var token = await this.UserManager.GeneratePasswordResetTokenAsync(user);
            await this.UserManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
            return RequestResponse.Success();
        }
    }
}
