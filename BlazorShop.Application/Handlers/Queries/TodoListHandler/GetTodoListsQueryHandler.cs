// <copyright file="GetTodoListsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoListsQuery, TodoListResponse}"/>.
    /// </summary>
    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, Result<TodoListResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetTodoListsQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoListsQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoListsQueryHandler> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetTodoListsQueryHandler}"/>.
        /// </summary>
        private ILogger<GetTodoListsQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoListsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{TodoListResponse}"/>.</returns>
        public Task<Result<TodoListResponse>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            Result<TodoListResponse>? response;

            try
            {
                var result = this.DbContext.TodoLists
                    .TagWith(nameof(GetTodoListsQueryHandler))
                    .ProjectTo<TodoListResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<TodoListResponse>
                {
                    Successful = true,
                    Items = result ?? new List<TodoListResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetTodoListsQuery);
                response = new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.GetTodoListsQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
