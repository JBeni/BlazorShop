// <copyright file="DeleteAllCartsCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteAllCartsCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteAllCartsCommandHandler : IRequestHandler<DeleteAllCartsCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{DeleteAllCartsCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<DeleteAllCartsCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllCartsCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{DeleteAllCartsCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public DeleteAllCartsCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteAllCartsCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteAllCartsCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(DeleteAllCartsCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                _dbContext.Carts.RemoveRange(
                    _dbContext.Carts
                        .TagWith(nameof(DeleteAllCartsCommandHandler))
                        .Where(x => x.User.Id == request.UserId)
                );
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteAllCartsCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteAllCartsCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
