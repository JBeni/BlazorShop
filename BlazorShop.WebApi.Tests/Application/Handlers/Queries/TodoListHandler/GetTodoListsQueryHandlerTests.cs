// <copyright file="GetTodoListsQueryHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.TodoListHandler
{
    /// <summary>
    /// Tests for <see cref="GetTodoListsQueryHandler"/>.
    /// </summary>
    public class GetTodoListsQueryHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetTodoListsQueryHandlerTests> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListsQueryHandlerTests"/> class.
        /// </summary>
        public GetTodoListsQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetTodoListsQueryHandlerTests> logger, IMapper mapper)
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
        public async Task Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
