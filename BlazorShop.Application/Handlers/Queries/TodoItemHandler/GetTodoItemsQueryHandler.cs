// <copyright file="GetTodoItemsQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoItemsQuery, Result{TodoItemResponse}}"/>.
    /// </summary>
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, Result<TodoItemResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetTodoItemsQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetTodoItemsQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetTodoItemsQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoItemsQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoItemsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoItemsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{TodoItemResponse}}"/>.</returns>
        public Task<Result<TodoItemResponse>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            Result<TodoItemResponse>? response;

            try
            {
                var result = _dbContext.TodoItems
                    .TagWith(nameof(GetTodoItemsQueryHandler))
                    .ProjectTo<TodoItemResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<TodoItemResponse>
                {
                    Successful = true,
                    Items = result ?? new List<TodoItemResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoItemsQuery);
                response = new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.GetTodoItemsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
