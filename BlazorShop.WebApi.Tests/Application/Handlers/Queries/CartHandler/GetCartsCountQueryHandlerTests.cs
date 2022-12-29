// <copyright file="GetCartsCountQueryHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// Tests for <see cref="GetCartsCountQueryHandler"/>.
    /// </summary>
    public class GetCartsCountQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartsCountQueryHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsCountQueryHandlerTests"/> class.
        /// </summary>
        public GetCartsCountQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetCartsCountQueryHandlerTests> logger)
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
        public async Task Handle(GetCartsCountQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
