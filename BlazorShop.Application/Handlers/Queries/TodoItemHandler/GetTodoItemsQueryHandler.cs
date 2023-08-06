// <copyright file="GetTodoItemsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoItemsQuery, TodoItemResponse}"/>.
    /// </summary>
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, Result<TodoItemResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetTodoItemsQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoItemsQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoItemsQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetTodoItemsQueryHandler}"/>.
        /// </summary>
        private ILogger<GetTodoItemsQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoItemsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{TodoItemResponse}"/>.</returns>
        public Task<Result<TodoItemResponse>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            Result<TodoItemResponse>? response;

            try
            {
                var result = this.DbContext.TodoItems
                    .TagWith(nameof(GetTodoItemsQueryHandler))
                    .ProjectTo<TodoItemResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<TodoItemResponse>
                {
                    Successful = true,
                    Items = result ?? new List<TodoItemResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetTodoItemsQuery);
                response = new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.GetTodoItemsQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
