// <copyright file="GetOrdersQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="GetOrdersQueryHandler"/>.
    /// </summary>
    public class GetOrdersQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetOrdersQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrdersQueryHandlerTests"/> class.
        /// </summary>
        public GetOrdersQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetOrdersQueryHandlerTests> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
