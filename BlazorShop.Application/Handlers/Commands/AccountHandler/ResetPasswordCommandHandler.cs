// <copyright file="ResetPasswordCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{ResetPasswordCommand, RequestResponse}"/>.
    /// </summary>
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">Gets An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{ResetPasswordCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public ResetPasswordCommandHandler(IAccountService accountService, ILogger<ResetPasswordCommandHandler> logger)
        {
            this.AccountService = accountService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IAccountService"/>.
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{ResetPasswordCommandHandler}"/>.
        /// </summary>
        private ILogger<ResetPasswordCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="ResetPasswordCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await this.AccountService.ResetPasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.ResetPasswordCommand);
                response = RequestResponse.Failure($"{ErrorsManager.ResetPasswordCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
