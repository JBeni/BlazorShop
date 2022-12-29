// <copyright file="GetTodoListsQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoListsQuery, Result{TodoListResponse}}"/>.
    /// </summary>
    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, Result<TodoListResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetTodoListsQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetTodoListsQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetTodoListsQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoListsQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoListsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoListsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{TodoListResponse}}"/>.</returns>
        public Task<Result<TodoListResponse>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            Result<TodoListResponse>? response;

            try
            {
                var result = _dbContext.TodoLists
                    .TagWith(nameof(GetTodoListsQueryHandler))
                    .ProjectTo<TodoListResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<TodoListResponse>
                {
                    Successful = true,
                    Items = result ?? new List<TodoListResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoListsQuery);
                response = new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.GetTodoListsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
