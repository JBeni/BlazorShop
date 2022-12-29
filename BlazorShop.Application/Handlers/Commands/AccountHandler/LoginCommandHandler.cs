// <copyright file="LoginCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{LoginCommand, RequestResponse}"/>.
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenResponse>
    {
        /// <summary>
        /// An instance of <see cref="IAccountService"/>.
        /// </summary>
        private readonly IAccountService _accountService;

        /// <summary>
        /// An instance of <see cref="ILogger{LoginCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<LoginCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{LoginCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public LoginCommandHandler(IAccountService accountService, ILogger<LoginCommandHandler> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="LoginCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{JwtTokenResponse}"/>.</returns>
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
