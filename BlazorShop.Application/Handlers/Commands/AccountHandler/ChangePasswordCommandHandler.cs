// <copyright file="ChangePasswordCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    ///     /// <summary>
    /// An implementation of the <see cref="IRequestHandler{ChangePasswordCommand, RequestResponse}"/>.
    /// </summary>
    /// </summary>
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IAccountService"/>.
        /// </summary>
        private readonly IAccountService _accountService;

        /// <summary>
        /// An instance of <see cref="ILogger{ChangePasswordCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<ChangePasswordCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandHandler"/> class.
        /// </summary>
        /// <param name="accountService">An instance of <see cref="IAccountService"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{ChangePasswordCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public ChangePasswordCommandHandler(IAccountService accountService, ILogger<ChangePasswordCommandHandler> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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
                response = await _accountService.ChangePasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.ChangePasswordCommand);
                response = RequestResponse.Failure($"{ErrorsManager.ChangePasswordCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
