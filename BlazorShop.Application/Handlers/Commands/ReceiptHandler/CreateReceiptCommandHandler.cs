// <copyright file="CreateReceiptCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateReceiptCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReceiptCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateReceiptCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<CreateReceiptCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateReceiptCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateReceiptCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateReceiptCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = new Receipt
                {
                    UserEmail = request.UserEmail,
                    ReceiptDate = request.ReceiptDate,
                    ReceiptName = request.ReceiptName,
                    ReceiptUrl = request.ReceiptUrl,
                };

                this.DbContext.Receipts.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateReceiptCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
