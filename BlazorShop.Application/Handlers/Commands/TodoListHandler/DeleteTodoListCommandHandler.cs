// <copyright file="DeleteTodoListCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{DeleteTodoListCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<DeleteTodoListCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoListCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateUserCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteTodoListCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteTodoListCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteTodoListCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.TodoLists
                    .TagWith(nameof(DeleteTodoListCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The todo list record does not exists in the database");

                _dbContext.TodoLists.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteTodoListCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteTodoListCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
