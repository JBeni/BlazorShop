// <copyright file="CreateSubscriberCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="CreateSubscriberCommandHandler"/>.
    /// </summary>
    public class CreateSubscriberCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateSubscriberCommandHandlerTests> Logger { get; }
        private IUserService UserService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public CreateSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateSubscriberCommandHandlerTests> logger, IUserService userService)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(CreateSubscriberCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
