﻿namespace BlazorShop.Application.Handlers.Queries.TodoListHandler
{
    public class GetTodoListByIdQueryHandler : IRequestHandler<GetTodoListByIdQuery, Result<TodoListResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetTodoListByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetTodoListByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoListByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<Result<TodoListResponse>> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.TodoLists
                    .ProjectTo<TodoListResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                return Task.FromResult(new Result<TodoListResponse>
                {
                    Successful = true,
                    Item = result ?? new TodoListResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoListByIdQuery);
                return Task.FromResult(new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.GetTodoListByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}