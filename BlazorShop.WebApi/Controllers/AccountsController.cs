namespace BlazorShop.WebApi.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly ICurrentUserService _currentUserService;

        public AccountsController(IConfiguration configuration,
                                  IEmailService emailService,
                                  ICurrentUserService currentUserService)
        {
            _configuration = configuration;
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
            var result = await Mediator.Send(login);

            return result.Successful == true
                ? Ok(result)
                : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterCommand register)
        {
            var result = await Mediator.Send(register);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordUser([FromBody] ChangePasswordCommand changePassword)
        {
            var result = await Mediator.Send(changePassword);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordUser([FromForm] ResetPasswordCommand resetPassword)
        {
            var emailSettings = new EmailSettings
            {
                Host = _configuration["BusinessEmail:Host"],
                Port = int.Parse(_configuration["BusinessEmail:Port"]),
                Subject = _configuration["BusinessEmail:Subject"],
                Message = _configuration["BusinessEmail:Message"],
                Username = _configuration["BusinessEmail:Username"],
                Password = _configuration["BusinessEmail:Password"]
            };
            //await _emailService.SendEmail(resetPassword.Email, emailSettings);

            var result = await Mediator.Send(resetPassword);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
