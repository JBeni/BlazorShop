namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateTodoItemCommandHandler> _logger;

        public UpdateTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateTodoItemCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.TodoItems.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                entity.Title = request.Title;
                entity.Note = request.Note;
                entity.Priority = request.Priority;
                entity.State = request.State;
                entity.Done = request.Done;

                _dbContext.TodoItems.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateTodoItemCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
