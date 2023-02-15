// <copyright file="DeleteReceiptCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteReceiptCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteReceiptCommandHandler : IRequestHandler<DeleteReceiptCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReceiptCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteReceiptCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteReceiptCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteReceiptCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteReceiptCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteReceiptCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Receipts
                    .TagWith(nameof(DeleteReceiptCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The receipt does not exists");
                }

                this.DbContext.Receipts.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteReceiptCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
