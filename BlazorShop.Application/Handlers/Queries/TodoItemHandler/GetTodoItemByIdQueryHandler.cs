// <copyright file="GetTodoItemByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoItemHandler
{
    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, Result<TodoItemResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetTodoItemByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetTodoItemByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoItemByIdQueryHandler> logger, IMapper mapper)
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
        public Task<Result<TodoItemResponse>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.TodoItems
                    .TagWith(nameof(GetTodoItemByIdQueryHandler))
                    .ProjectTo<TodoItemResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                return Task.FromResult(new Result<TodoItemResponse>
                {
                    Successful = true,
                    Item = result ?? new TodoItemResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoItemByIdQuery);
                return Task.FromResult(new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.GetTodoItemByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
