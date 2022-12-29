// <copyright file="DeleteAllCartsCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteAllCartsCommandHandler"/>.
    /// </summary>
    public class DeleteAllCartsCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteAllCartsCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllCartsCommandHandlerTests"/> class.
        /// </summary>
        public DeleteAllCartsCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteAllCartsCommandHandlerTests> logger)
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
        public async Task Handle(DeleteAllCartsCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
