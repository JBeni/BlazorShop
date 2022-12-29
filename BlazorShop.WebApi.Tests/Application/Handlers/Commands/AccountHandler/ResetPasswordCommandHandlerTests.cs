// <copyright file="ResetPasswordCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ResetPasswordCommandHandler"/>.
    /// </summary>
    public class ResetPasswordCommandHandlerTests
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<ResetPasswordCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandlerTests"/> class.
        /// </summary>
        public ResetPasswordCommandHandlerTests(IAccountService accountService, ILogger<ResetPasswordCommandHandlerTests> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
