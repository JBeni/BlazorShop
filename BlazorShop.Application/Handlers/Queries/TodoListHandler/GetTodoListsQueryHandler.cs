namespace BlazorShop.Application.Handlers.Queries.TodoListHandler
{
    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, Result<TodoListResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetTodoListsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetTodoListsQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoListsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<Result<TodoListResponse>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.TodoLists
                    .ProjectTo<TodoListResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<TodoListResponse>
                {
                    Successful = true,
                    Items = result ?? new List<TodoListResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoListsQuery);
                return Task.FromResult(new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.GetTodoListsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
