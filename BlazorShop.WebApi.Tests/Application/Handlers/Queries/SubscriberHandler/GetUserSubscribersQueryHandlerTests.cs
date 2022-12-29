// <copyright file="GetUserSubscribersQueryHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="GetUserSubscribersQueryHandler"/>.
    /// </summary>
    public class GetUserSubscribersQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetUserSubscribersQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserSubscribersQueryHandlerTests"/> class.
        /// </summary>
        public GetUserSubscribersQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetUserSubscribersQueryHandlerTests> logger, IMapper mapper)
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
        public async Task Handle(GetUserSubscribersQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
