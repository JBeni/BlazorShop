namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Result<TodoItemResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateTodoItemCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<CreateTodoItemCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public async Task<Result<TodoItemResponse>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var list = _dbContext.TodoLists.FirstOrDefault(x => x.Id == request.ListId);
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
                return new Result<TodoItemResponse>
                {
                    Successful = true,
                    Item = _mapper.Map<TodoItemResponse>(entity) ?? new TodoItemResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateTodoItemCommand);
                return new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.CreateTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }
        }
    }
}
