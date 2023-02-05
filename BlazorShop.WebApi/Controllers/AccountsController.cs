// <copyright file="AccountsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Accounts.
    /// </summary>
    public class AccountsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="configuration">The instance of the <see cref="IConfiguration"/> to use.</param>
        /// <param name="emailService">The instance of the <see cref="IEmailService"/> to use.</param>
        public AccountsController(
            IConfiguration configuration,
            IEmailService emailService)
        {
            this.Configuration = configuration;
            this.EmailService = emailService;
        }

        /// <summary>
        /// Gets the instance of the <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IEmailService"/> to use.
        /// </summary>
        private IEmailService EmailService { get; }

        /// <summary>
        /// Log in the user.
        /// </summary>
        /// <param name="login">The login command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromForm] LoginCommand login)
        {
            var result = await this.Mediator.Send(login);

            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Register the user.
        /// </summary>
        /// <param name="register">The register command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterCommand register)
        {
            var result = await this.Mediator.Send(register);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Changing the password.
        /// </summary>
        /// <param name="changePassword">The change password command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordUser([FromBody] ChangePasswordCommand changePassword)
        {
            var result = await this.Mediator.Send(changePassword);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Resetting the user password.
        /// </summary>
        /// <param name="resetPassword">The reset password command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordUser([FromForm] ResetPasswordCommand resetPassword)
        {
            var emailSettings = new EmailSettings
            {
                Host = this.Configuration["BusinessEmail:Host"],
                Port = int.Parse(this.Configuration["BusinessEmail:Port"]),
                Subject = this.Configuration["BusinessEmail:Subject"],
                Message = this.Configuration["BusinessEmail:Message"],
                Username = this.Configuration["BusinessEmail:Username"],
                Password = this.Configuration["BusinessEmail:Password"],
            };

            // await _emailService.SendEmail(resetPassword.Email, emailSettings);
            var result = await this.Mediator.Send(resetPassword);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
