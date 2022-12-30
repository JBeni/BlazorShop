// <copyright file="ChangePasswordCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{ChangePasswordCommand, RequestResponse}"/>.
    /// </summary>
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">Gets An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{ChangePasswordCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public ChangePasswordCommandHandler(IAccountService accountService, ILogger<ChangePasswordCommandHandler> logger)
        {
            this.AccountService = accountService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IAccountService"/>.
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{ChangePasswordCommandHandler}"/>.
        /// </summary>
        private ILogger<ChangePasswordCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="ChangePasswordCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.AccountService.ChangePasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.ChangePasswordCommand);
                response = RequestResponse.Failure($"{ErrorsManager.ChangePasswordCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
