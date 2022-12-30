// <copyright file="UpdateOrderCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateOrderCommandHandler"/>.
    /// </summary>
    public class UpdateOrderCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateOrderCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCommandHandlerTests"/> class.
        /// </summary>
        public UpdateOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateOrderCommandHandlerTests> logger)
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
        public Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
