// <copyright file="GetCartsQueryHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// Tests for <see cref="GetCartsQueryHandler"/>.
    /// </summary>
    public class GetCartsQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartsQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsQueryHandlerTests"/> class.
        /// </summary>
        public GetCartsQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetCartsQueryHandlerTests> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
