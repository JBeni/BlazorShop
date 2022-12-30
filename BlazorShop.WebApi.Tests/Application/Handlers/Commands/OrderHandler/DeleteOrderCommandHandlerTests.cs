// <copyright file="DeleteOrderCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteOrderCommandHandler"/>.
    /// </summary>
    public class DeleteOrderCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteOrderCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOrderCommandHandlerTests"/> class.
        /// </summary>
        public DeleteOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteOrderCommandHandlerTests> logger)
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
        public Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
