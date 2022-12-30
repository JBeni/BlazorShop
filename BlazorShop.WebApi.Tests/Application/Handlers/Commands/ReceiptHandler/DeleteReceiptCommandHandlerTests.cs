// <copyright file="DeleteReceiptCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteReceiptCommandHandler"/>.
    /// </summary>
    public class DeleteReceiptCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteReceiptCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReceiptCommandHandlerTests"/> class.
        /// </summary>
        public DeleteReceiptCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteReceiptCommandHandlerTests> logger)
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
        public Task Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
