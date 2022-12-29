// <copyright file="ResetPasswordCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IAccountService"/>.
        /// </summary>
        private readonly IAccountService _accountService;

        /// <summary>
        /// An instance of <see cref="ILogger{ResetPasswordCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<ResetPasswordCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{ResetPasswordCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public ResetPasswordCommandHandler(IAccountService accountService, ILogger<ResetPasswordCommandHandler> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="ResetPasswordCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                response = await _accountService.ResetPasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.ResetPasswordCommand);
                response = RequestResponse.Failure($"{ErrorsManager.ResetPasswordCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
