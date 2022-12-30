// <copyright file="GetCartsQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// Tests for <see cref="GetCartsQueryHandler"/>.
    /// </summary>
    public class GetCartsQueryHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<GetCartsQueryHandlerTests> Logger { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsQueryHandlerTests"/> class.
        /// </summary>
        public GetCartsQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetCartsQueryHandlerTests> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
