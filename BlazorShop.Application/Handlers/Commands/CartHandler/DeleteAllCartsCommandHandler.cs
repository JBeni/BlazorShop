// <copyright file="DeleteAllCartsCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="DeleteAllCartsCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteAllCartsCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteAllCartsCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteAllCartsCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteAllCartsCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteAllCartsCommandHandler> Logger { get; }

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
                this.DbContext.Carts.RemoveRange(
                    this.DbContext.Carts
                        .TagWith(nameof(DeleteAllCartsCommandHandler))
                        .Where(x => x.User.Id == request.UserId));
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteAllCartsCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteAllCartsCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
