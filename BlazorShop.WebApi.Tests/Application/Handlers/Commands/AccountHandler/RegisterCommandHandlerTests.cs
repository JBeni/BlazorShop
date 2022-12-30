// <copyright file="RegisterCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// for <see cref="RegisterCommandHandler"/>.
    /// </summary>
    public class RegisterCommandHandlerTests
    {
        private IAccountService AccountService { get; }
        private ILogger<RegisterCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCommandHandlerTests"/> class.
        /// </summary>
        public RegisterCommandHandlerTests(IAccountService accountService, ILogger<RegisterCommandHandlerTests> logger)
        {
            this.AccountService = accountService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
