// <copyright file="CreateInvoiceCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// Tests for <see cref="CreateInvoiceCommandHandler"/>.
    /// </summary>
    public class CreateInvoiceCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateInvoiceCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceCommandHandlerTests"/> class.
        /// </summary>
        public CreateInvoiceCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateInvoiceCommandHandlerTests> logger)
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
        public Task Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
