// <copyright file="GetTodoListByIdQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoListByIdQuery, Result{TodoListResponse}}"/>.
    /// </summary>
    public class GetTodoListByIdQueryHandler : IRequestHandler<GetTodoListByIdQuery, Result<TodoListResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetTodoListByIdQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetTodoListByIdQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetTodoListByIdQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoListByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoListByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoListByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{TodoListResponse}}"/>.</returns>
        public Task<Result<TodoListResponse>> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            Result<TodoListResponse>? response;

            try
            {
                var result = _dbContext.TodoLists
                    .TagWith(nameof(GetTodoListByIdQueryHandler))
                    .ProjectTo<TodoListResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                response = new Result<TodoListResponse>
                {
                    Successful = true,
                    Item = result ?? new TodoListResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoListByIdQuery);
                response = new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.GetTodoListByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}
