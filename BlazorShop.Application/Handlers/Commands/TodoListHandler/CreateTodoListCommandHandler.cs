// <copyright file="CreateTodoListCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Result<TodoListResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateTodoListCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<CreateTodoListCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<TodoListResponse>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new TodoList
                {
                    Title = request.Title,
                };

                _dbContext.TodoLists.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new Result<TodoListResponse>
                {
                    Successful = true,
                    Item = _mapper.Map<TodoListResponse>(entity) ?? new TodoListResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateTodoListCommand);
                return new Result<TodoListResponse>
                {
                    Error = $"{ErrorsManager.CreateTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }
        }
    }
}
