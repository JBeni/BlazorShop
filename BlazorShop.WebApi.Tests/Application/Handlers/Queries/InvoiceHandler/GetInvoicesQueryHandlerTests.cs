// <copyright file="GetInvoicesQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="GetInvoicesQueryHandler"/>.
    /// </summary>
    public class GetInvoicesQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetInvoicesQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoicesQueryHandlerTests"/> class.
        /// </summary>
        public GetInvoicesQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetInvoicesQueryHandlerTests> logger, IMapper mapper)
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
        public async Task Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
