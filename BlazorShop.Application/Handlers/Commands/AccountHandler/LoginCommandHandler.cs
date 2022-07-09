// <copyright file="LoginCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenResponse>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(IAccountService accountService, ILogger<LoginCommandHandler> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JwtTokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            JwtTokenResponse? response;

            try
            {
                response = await _accountService.LoginAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.LoginCommand);
                response = JwtTokenResponse.Failure($"{ErrorsManager.LoginCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
