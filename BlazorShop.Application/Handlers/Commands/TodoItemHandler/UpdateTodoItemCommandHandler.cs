// <copyright file="UpdateTodoItemCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateTodoItemCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateTodoItemCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateTodoItemCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateTodoItemCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateTodoItemCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateTodoItemCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.TodoItems
                    .TagWith(nameof(UpdateTodoItemCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The todo list record does not exists in the database");
                }

                entity.Title = request.Title;
                entity.Note = request.Note;
                entity.Priority = request.Priority;
                entity.State = request.State;
                entity.Done = request.Done;

                this.DbContext.TodoItems.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateTodoItemCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
