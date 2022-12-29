// <copyright file="ChangePasswordCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ChangePasswordCommandHandler"/>.
    /// </summary>
    public class ChangePasswordCommandHandlerTests
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<ChangePasswordCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandHandlerTests"/> class.
        /// </summary>
        public ChangePasswordCommandHandlerTests(IAccountService accountService, ILogger<ChangePasswordCommandHandlerTests> logger)
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
        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
