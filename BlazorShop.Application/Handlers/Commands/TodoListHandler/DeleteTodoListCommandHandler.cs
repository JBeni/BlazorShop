// <copyright file="DeleteTodoListCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteTodoListCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoListCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteTodoListCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteTodoListCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteTodoListCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteTodoListCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.TodoLists
                    .TagWith(nameof(DeleteTodoListCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The todo list record does not exists in the database");
                }

                this.DbContext.TodoLists.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteTodoListCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
