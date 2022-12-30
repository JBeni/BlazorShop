// <copyright file="UpdateTodoListCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.TodoListHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateTodoListCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoListCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateTodoListCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateTodoListCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateTodoListCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateTodoListCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.TodoLists
                    .TagWith(nameof(UpdateTodoListCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The todo list record does not exists in the database");
                }

                entity.Title = request.Title;

                this.DbContext.TodoLists.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateTodoListCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
