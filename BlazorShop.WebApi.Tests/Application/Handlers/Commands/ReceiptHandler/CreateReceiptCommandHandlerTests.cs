// <copyright file="CreateReceiptCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// Tests for <see cref="CreateReceiptCommandHandler"/>.
    /// </summary>
    public class CreateReceiptCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateReceiptCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReceiptCommandHandlerTests"/> class.
        /// </summary>
        public CreateReceiptCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateReceiptCommandHandlerTests> logger)
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
        public Task Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
