// <copyright file="CreateOrderCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="CreateOrderCommandHandler"/>.
    /// </summary>
    public class CreateOrderCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateOrderCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCommandHandlerTests"/> class.
        /// </summary>
        public CreateOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateOrderCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
