// <copyright file="UpdateCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateCartCommandHandler"/>.
    /// </summary>
    public class UpdateCartCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateCartCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCartCommandHandlerTests"/> class.
        /// </summary>
        public UpdateCartCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateCartCommandHandlerTests> logger)
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
        public Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
