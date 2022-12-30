// <copyright file="UpdateInvoiceCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateInvoiceCommandHandler"/>.
    /// </summary>
    public class UpdateInvoiceCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateInvoiceCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvoiceCommandHandlerTests"/> class.
        /// </summary>
        public UpdateInvoiceCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateInvoiceCommandHandlerTests> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
