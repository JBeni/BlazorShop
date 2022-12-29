// <copyright file="LoginCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="LoginCommandHandler"/>.
    /// </summary>
    public class LoginCommandHandlerTests
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<LoginCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginCommandHandlerTests"/> class.
        /// </summary>
        public LoginCommandHandlerTests(IAccountService accountService, ILogger<LoginCommandHandlerTests> logger)
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
        public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
