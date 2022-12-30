// <copyright file="CreateOrderCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="CreateOrderCommandHandler"/>.
    /// </summary>
    public class CreateOrderCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateOrderCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCommandHandlerTests"/> class.
        /// </summary>
        public CreateOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateOrderCommandHandlerTests> logger)
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
        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
