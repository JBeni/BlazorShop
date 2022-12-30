// <copyright file="ResetPasswordCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ResetPasswordCommandHandler"/>.
    /// </summary>
    public class ResetPasswordCommandHandlerTests
    {
        private IAccountService AccountService { get; }
        private ILogger<ResetPasswordCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandlerTests"/> class.
        /// </summary>
        public ResetPasswordCommandHandlerTests(IAccountService accountService, ILogger<ResetPasswordCommandHandlerTests> logger)
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
        public Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
