// <copyright file="UpdateTodoItemCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateTodoItemCommandHandler> _logger;

        public UpdateTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateTodoItemCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.TodoItems
                    .TagWith(nameof(UpdateTodoItemCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                entity.Title = request.Title;
                entity.Note = request.Note;
                entity.Priority = request.Priority;
                entity.State = request.State;
                entity.Done = request.Done;

                _dbContext.TodoItems.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateTodoItemCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
