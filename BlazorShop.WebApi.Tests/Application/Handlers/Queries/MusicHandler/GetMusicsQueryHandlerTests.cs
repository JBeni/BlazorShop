// <copyright file="GetMusicsQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="GetMusicsQueryHandler"/>.
    /// </summary>
    public class GetMusicsQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetMusicsQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMusicsQueryHandlerTests"/> class.
        /// </summary>
        public GetMusicsQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetMusicsQueryHandlerTests> logger, IMapper mapper)
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
        public async Task Handle(GetMusicsQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
