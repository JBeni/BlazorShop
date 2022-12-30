// <copyright file="LoginCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="LoginCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">Gets An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{LoginCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public LoginCommandHandler(IAccountService accountService, ILogger<LoginCommandHandler> logger)
        {
            this.AccountService = accountService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IAccountService"/>.
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{LoginCommandHandler}"/>.
        /// </summary>
        private ILogger<LoginCommandHandler> Logger { get; }

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
                response = await this.AccountService.LoginAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.LoginCommand);
                response = JwtTokenResponse.Failure($"{ErrorsManager.LoginCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
