// <copyright file="CreateInvoiceCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateInvoiceCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateInvoiceCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateInvoiceCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateInvoiceCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>

        public CreateInvoiceCommandHandler(IApplicationDbContext dbContext, ILogger<CreateInvoiceCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateInvoiceCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = new Invoice
                {
                    UserEmail = request.UserEmail,
                    Name = request.Name,
                    AmountSubTotal = request.AmountSubTotal,
                    AmountTotal = request.AmountTotal,
                    Quantity = request.Quantity,
                };

                _dbContext.Invoices.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateInvoiceCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateInvoiceCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
