// <copyright file="GetTodoItemByIdQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetTodoItemByIdQuery, TodoItemResponse}"/>.
    /// </summary>
    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, Result<TodoItemResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetTodoItemByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetTodoItemByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoItemByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetTodoItemByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetTodoItemByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetTodoItemByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{TodoItemResponse}"/>.</returns>
        public Task<Result<TodoItemResponse>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            Result<TodoItemResponse>? response;

            try
            {
                var result = this.DbContext.TodoItems
                    .TagWith(nameof(GetTodoItemByIdQueryHandler))
                    .ProjectTo<TodoItemResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                response = new Result<TodoItemResponse>
                {
                    Successful = true,
                    Item = result ?? new TodoItemResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetTodoItemByIdQuery);
                response = new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.GetTodoItemByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}
