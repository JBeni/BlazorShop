// <copyright file="DeleteSubscriberCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteSubscriberCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteSubscriberCommandHandler : IRequestHandler<DeleteSubscriberCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{DeleteSubscriberCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<DeleteSubscriberCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriberCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{DeleteSubscriberCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteSubscriberCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(DeleteSubscriberCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Subscribers
                    .TagWith(nameof(DeleteSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The subscriber does not exists");

                _dbContext.Subscribers.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteSubscriberCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
