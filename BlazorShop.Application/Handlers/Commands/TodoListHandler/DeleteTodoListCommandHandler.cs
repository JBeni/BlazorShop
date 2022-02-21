namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteTodoListCommandHandler> _logger;

        public DeleteTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteTodoListCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.TodoLists.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                _dbContext.TodoLists.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteTodoListCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
