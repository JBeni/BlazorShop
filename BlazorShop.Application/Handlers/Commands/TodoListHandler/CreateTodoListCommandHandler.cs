// <copyright file="CreateTodoListCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateTodoListCommand, TodoListResponse}"/>.
    /// </summary>
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Result<TodoListResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoListCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateTodoListCommandHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<CreateTodoListCommandHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{CreateTodoListCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateTodoListCommandHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateTodoListCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{TodoListResponse}"/>.</returns>
        public async Task<Result<TodoListResponse>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            Result<TodoListResponse>? response;

            try
            {
                var entity = new TodoList
                {
                    Title = request.Title,
                };

                this.DbContext.TodoLists.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = new Result<TodoListResponse>
                {
                    Successful = true,
                    Item = this.Mapper.Map<TodoListResponse>(entity) ?? new TodoListResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateTodoListCommand);
                response = new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.CreateTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return response;
        }
    }
}
