﻿// <copyright file="GetTodoListByIdQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="GetTodoListByIdQueryHandler"/>.
    /// </summary>
    public class GetTodoListByIdQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetTodoListByIdQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetTodoListByIdQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetTodoListByIdQueryHandlerTests> logger, IMapper mapper)
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
        public async Task Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
        }
    }
}