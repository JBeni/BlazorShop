// <copyright file="RegisterCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{RegisterCommand, RequestResponse}"/>.
    /// </summary>
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, JwtTokenResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">Gets An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{RegisterCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public RegisterCommandHandler(IAccountService accountService, ILogger<RegisterCommandHandler> logger)
        {
            this.AccountService = accountService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IAccountService"/>.
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{RegisterCommandHandler}"/>.
        /// </summary>
        private ILogger<RegisterCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="RegisterCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{JwtTokenResponse}"/>.</returns>
        public async Task<JwtTokenResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            JwtTokenResponse? response;

            try
            {
                response = await this.AccountService.RegisterAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.RegisterCommand);
                response = JwtTokenResponse.Failure($"{ErrorsManager.RegisterCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
