// <copyright file="DeleteSubscriberCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="DeleteSubscriberCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteSubscriberCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteSubscriberCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteSubscriberCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteSubscriberCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteSubscriberCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Subscribers
                    .TagWith(nameof(DeleteSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The subscriber does not exists");
                }

                this.DbContext.Subscribers.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteSubscriberCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
