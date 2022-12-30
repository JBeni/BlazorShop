// <copyright file="UpdateInvoiceCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateInvoiceCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvoiceCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateInvoiceCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateInvoiceCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateInvoiceCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateInvoiceCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateInvoiceCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateInvoiceCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Invoices
                    .TagWith(nameof(UpdateInvoiceCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The invoice does not exists");
                }

                entity.UserEmail = request.UserEmail;
                entity.Name = request.Name;
                entity.AmountSubTotal = request.AmountSubTotal;
                entity.AmountTotal = request.AmountTotal;
                entity.Quantity = request.Quantity;

                this.DbContext.Invoices.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateInvoiceCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateInvoiceCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}
