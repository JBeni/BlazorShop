// <copyright file="CreateReceiptCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateReceiptCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateReceiptCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReceiptCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateReceiptCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<CreateReceiptCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateReceiptCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
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

                _dbContext.Receipts.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateReceiptCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
