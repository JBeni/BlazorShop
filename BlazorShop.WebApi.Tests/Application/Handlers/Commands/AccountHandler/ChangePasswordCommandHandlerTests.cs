// <copyright file="ChangePasswordCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ChangePasswordCommandHandler"/>.
    /// </summary>
    public class ChangePasswordCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandHandlerTests"/> class.
        /// </summary>
        public ChangePasswordCommandHandlerTests(IAccountService accountService, ILogger<ChangePasswordCommandHandlerTests> logger)
        {
            this.AccountService = accountService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets.
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        private ILogger<ChangePasswordCommandHandlerTests> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
