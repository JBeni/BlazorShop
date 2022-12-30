// <copyright file="CreateInvoiceCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="CreateInvoiceCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateInvoiceCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateInvoiceCommandHandler(IApplicationDbContext dbContext, ILogger<CreateInvoiceCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateInvoiceCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateInvoiceCommandHandler> Logger { get; }

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

                this.DbContext.Invoices.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateInvoiceCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateInvoiceCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
