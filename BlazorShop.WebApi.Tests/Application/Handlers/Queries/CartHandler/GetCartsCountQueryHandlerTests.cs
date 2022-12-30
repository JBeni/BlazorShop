// <copyright file="GetCartsCountQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// Tests for <see cref="GetCartsCountQueryHandler"/>.
    /// </summary>
    public class GetCartsCountQueryHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<GetCartsCountQueryHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsCountQueryHandlerTests"/> class.
        /// </summary>
        public GetCartsCountQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetCartsCountQueryHandlerTests> logger)
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
        public Task Handle(GetCartsCountQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
