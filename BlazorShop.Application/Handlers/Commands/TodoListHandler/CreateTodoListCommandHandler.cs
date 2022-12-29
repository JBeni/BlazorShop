// <copyright file="CreateTodoListCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateTodoListCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Result<TodoListResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateTodoListCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateTodoListCommandHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoListCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateTodoListCommandHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<CreateTodoListCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateTodoListCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<Result<TodoListResponse>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            Result<TodoListResponse>? response;

            try
            {
                var entity = new TodoList
                {
                    Title = request.Title,
                };

                _dbContext.TodoLists.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = new Result<TodoListResponse>
                {
                    Successful = true,
                    Item = _mapper.Map<TodoListResponse>(entity) ?? new TodoListResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateTodoListCommand);
                response = new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.CreateTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return response;
        }
    }
}
