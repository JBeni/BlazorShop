// <copyright file="GetTodoListByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoListByIdQuery, TodoListResponse}"/>.
    /// </summary>
    public class GetTodoListByIdQueryHandler : IRequestHandler<GetTodoListByIdQuery, Result<TodoListResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetTodoListByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoListByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoListByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetTodoListByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetTodoListByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoListByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{TodoListResponse}"/>.</returns>
        public Task<Result<TodoListResponse>> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            Result<TodoListResponse>? response;

            try
            {
                var result = this.DbContext.TodoLists
                    .TagWith(nameof(GetTodoListByIdQueryHandler))
                    .ProjectTo<TodoListResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                response = new Result<TodoListResponse>
                {
                    Successful = true,
                    Item = result ?? new TodoListResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetTodoListByIdQuery);
                response = new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.GetTodoListByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
