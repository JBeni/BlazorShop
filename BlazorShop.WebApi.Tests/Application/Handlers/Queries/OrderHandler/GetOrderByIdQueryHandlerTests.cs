﻿// <copyright file="GetOrderByIdQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="GetOrderByIdQueryHandler"/>.
    /// </summary>
    public class GetOrderByIdQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetOrderByIdQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetOrderByIdQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetOrderByIdQueryHandlerTests> logger, IMapper mapper)
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
        public async Task Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
        }
    }
}