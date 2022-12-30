// <copyright file="DeleteCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteCartCommandHandler"/>.
    /// </summary>
    public class DeleteCartCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteCartCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCartCommandHandlerTests"/> class.
        /// </summary>
        public DeleteCartCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteCartCommandHandlerTests> logger)
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
        public Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
