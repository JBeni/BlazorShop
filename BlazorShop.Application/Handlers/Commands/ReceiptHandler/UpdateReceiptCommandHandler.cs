// <copyright file="UpdateReceiptCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateReceiptCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateReceiptCommandHandler : IRequestHandler<UpdateReceiptCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateReceiptCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateReceiptCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateReceiptCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateReceiptCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateReceiptCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateReceiptCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Receipts
                    .TagWith(nameof(UpdateReceiptCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The receipt does not exists");
                }

                entity.ReceiptDate = request.ReceiptDate;
                entity.ReceiptName = request.ReceiptName;
                entity.ReceiptUrl = request.ReceiptUrl;

                this.DbContext.Receipts.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateReceiptCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
