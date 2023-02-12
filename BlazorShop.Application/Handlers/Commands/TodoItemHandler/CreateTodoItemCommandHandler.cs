// <copyright file="CreateTodoItemCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateTodoItemCommand, TodoItemResponse}"/>.
    /// </summary>
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Result<TodoItemResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateTodoItemCommandHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<CreateTodoItemCommandHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{CreateTodoItemCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateTodoItemCommandHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateTodoItemCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{TodoItemResponse}"/>.</returns>
        public async Task<Result<TodoItemResponse>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            Result<TodoItemResponse>? response;

            try
            {
                var list = this.DbContext.TodoLists
                    .TagWith(nameof(CreateTodoItemCommandHandler))
                    .FirstOrDefault(x => x.Id == request.ListId);
                if (list != null)
                {
                    throw new Exception("The todo list record already exists in the database");
                }

                var entity = new TodoItem
                {
                    List = list,
                    Title = request.Title,
                    Note = request.Note,
                    Priority = request.Priority,
                    State = request.State,
                    Done = false,
                };

                this.DbContext.TodoItems.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = new Result<TodoItemResponse>
                {
                    Successful = true,
                    Item = this.Mapper.Map<TodoItemResponse>(entity) ?? new TodoItemResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateTodoItemCommand);
                response = new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.CreateTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return response;
        }
    }
}
