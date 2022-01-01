namespace BlazorShop.WebApi.Controllers
{
    public class AccountsController : ApiBaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IEncryptionService _encryptionService;
        private readonly IEmailService _emailService;
        private readonly ICurrentUserService _currentUserService;

        public AccountsController(
            IConfiguration configuration,
            IEncryptionService encryptionService,
            IEmailService emailService,
            ICurrentUserService currentUserService)
        {
            _configuration = configuration;
            _encryptionService = encryptionService;
            _emailService = emailService;
            _currentUserService = currentUserService;
        }

        [HttpGet("user")]
        public IActionResult GetIdentityClaims()
        {
            return Ok(value: new[] { _currentUserService.UserId });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromForm] LoginCommand login)
        {
            var loginCommand = new LoginCommand()
            {
                Email = _encryptionService.DecryptData(login.Email),
                Password = _encryptionService.DecryptData(login.Password)
            };

            var result = await Mediator.Send(loginCommand);
            var userId = await Mediator.Send(new GetUserByEmailQuery { Email = loginCommand.Email });
            await Mediator.Send(new CreateUserJwtTokenCommand
            {
                UserId = userId.Id,
                JwtToken = result.Access_Token,
                TokenTimestamp = DateTime.Now
            });

            return result.Successful == true
                ? Ok(result)
                : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterCommand register)
        {
            var registerCommand = new RegisterCommand
            {
                FirstName = register.FirstName,
                LastName = register.LastName,

                Email = _encryptionService.DecryptData(register.Email),
                Password = _encryptionService.DecryptData(register.Password),
                ConfirmPassword = _encryptionService.DecryptData(register.ConfirmPassword)
            };

            var result = await Mediator.Send(registerCommand);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            var result = await Mediator.Send(new DeleteUserJwtTokenCommand
            {
                // _currentUserService.UserId -> it returns null value
                UserId = int.Parse(_currentUserService.UserId)
            });
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordUser([FromBody] ChangePasswordCommand changePassword)
        {
            var changeCommand = new ChangePasswordCommand
            {
                UserId = _currentUserService.UserId,
                OldPassword = _encryptionService.DecryptData(changePassword.OldPassword),
                NewPassword = _encryptionService.DecryptData(changePassword.NewPassword),
                NewConfirmPassword = _encryptionService.DecryptData(changePassword.NewConfirmPassword)
            };

            var result = await Mediator.Send(changeCommand);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordUser([FromBody] ResetPasswordCommand resetPassword)
        {
            var resetCommand = new ResetPasswordCommand
            {
                Email = _encryptionService.DecryptData(resetPassword.Email),
                NewPassword = _encryptionService.DecryptData(resetPassword.NewPassword),
                NewConfirmPassword = _encryptionService.DecryptData(resetPassword.NewConfirmPassword)
            };

            //var email = _encryptionService.DecryptData(resetPassword.Email);
            //var emailSettings = new EmailSettings
            //{
            //    Host = _configuration["EmailSettings:Host"],
            //    Port = int.Parse(_configuration["EmailSettings:Port"]),
            //    Subject = _configuration["EmailSettings:Subject"],
            //    Message = _configuration["EmailSettings:Message"],
            //    Username = _configuration["EmailSettings:Username"],
            //    Password = _configuration["EmailSettings:Password"]
            //};
            //await _emailService.SendEmail(email, emailSettings);

            var result = await Mediator.Send(resetCommand);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
