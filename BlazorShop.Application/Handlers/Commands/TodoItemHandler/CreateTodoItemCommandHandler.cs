// <copyright file="CreateTodoItemCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateTodoItemCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Result<TodoItemResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateTodoItemCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateTodoItemCommandHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateTodoItemCommandHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<CreateTodoItemCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateTodoItemCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<Result<TodoItemResponse>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            Result<TodoItemResponse>? response;

            try
            {
                var list = _dbContext.TodoLists
                    .TagWith(nameof(CreateTodoItemCommandHandler))
                    .FirstOrDefault(x => x.Id == request.ListId);
                if (list != null) throw new Exception("The todo list record already exists in the database");

                var entity = new TodoItem
                {
                    List = list,
                    Title = request.Title,
                    Note = request.Note,
                    Priority = request.Priority,
                    State = request.State,
                    Done = false,
                };

                _dbContext.TodoItems.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = new Result<TodoItemResponse>
                {
                    Successful = true,
                    Item = _mapper.Map<TodoItemResponse>(entity) ?? new TodoItemResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateTodoItemCommand);
                response = new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.CreateTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return response;
        }
    }
}
