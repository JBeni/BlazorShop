﻿namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateTodoListCommandHandler> _logger;

        public UpdateTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateTodoListCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.TodoLists.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                entity.Title = request.Title;

                _dbContext.TodoLists.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateTodoListCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}