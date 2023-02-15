// <copyright file="DeleteTodoItemCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoItemHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteTodoItemCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteTodoItemCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteTodoItemCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteTodoItemCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteTodoItemCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteTodoItemCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteTodoItemCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.TodoItems
                    .TagWith(nameof(DeleteTodoItemCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The todo list record does not exists in the database");
                }

                this.DbContext.TodoItems.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteTodoItemCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteTodoItemCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
