// <copyright file="CreateReceiptCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateReceiptCommandHandler> _logger;

        public CreateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<CreateReceiptCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
