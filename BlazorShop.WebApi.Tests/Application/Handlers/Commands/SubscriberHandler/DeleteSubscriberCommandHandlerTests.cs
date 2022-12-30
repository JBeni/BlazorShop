// <copyright file="DeleteSubscriberCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteSubscriberCommandHandler"/>.
    /// </summary>
    public class DeleteSubscriberCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteSubscriberCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public DeleteSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteSubscriberCommandHandlerTests> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(DeleteSubscriberCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
