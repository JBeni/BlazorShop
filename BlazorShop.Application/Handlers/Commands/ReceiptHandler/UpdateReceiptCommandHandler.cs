// <copyright file="UpdateReceiptCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateReceiptCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateReceiptCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateReceiptCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateReceiptCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateReceiptCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateReceiptCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Receipts
                    .TagWith(nameof(UpdateReceiptCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The receipt does not exists");

                entity.ReceiptDate = request.ReceiptDate;
                entity.ReceiptName = request.ReceiptName;
                entity.ReceiptUrl = request.ReceiptUrl;

                _dbContext.Receipts.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateReceiptCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
