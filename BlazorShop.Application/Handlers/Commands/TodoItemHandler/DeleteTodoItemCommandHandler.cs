namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteTodoItemCommandHandler> _logger;

        public DeleteTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteTodoItemCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.TodoItems.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                _dbContext.TodoItems.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteTodoItemCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
