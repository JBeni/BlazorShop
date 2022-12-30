// <copyright file="DeleteInvoiceCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteInvoiceCommandHandler"/>.
    /// </summary>
    public class DeleteInvoiceCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteInvoiceCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteInvoiceCommandHandlerTests"/> class.
        /// </summary>
        public DeleteInvoiceCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteInvoiceCommandHandlerTests> logger)
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
        public Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
