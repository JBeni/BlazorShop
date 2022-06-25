// <copyright file="DeleteTodoItemCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteTodoItemCommandHandler> _logger;

        public DeleteTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteTodoItemCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task<RequestResponse> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.TodoItems
                    .TagWith(nameof(DeleteTodoItemCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                _dbContext.TodoItems.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteTodoItemCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
