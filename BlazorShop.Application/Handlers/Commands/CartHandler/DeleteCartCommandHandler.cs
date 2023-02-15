// <copyright file="DeleteCartCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteCartCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCartCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteCartCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteCartCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteCartCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteCartCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteCartCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteCartCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Carts
                    .TagWith(nameof(DeleteCartCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id && x.User.Id == request.UserId);
                if (entity == null)
                {
                    throw new Exception("The cart does not exists");
                }

                this.DbContext.Carts.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteCartCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
