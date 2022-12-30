// <copyright file="DeleteSubscriptionCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteSubscriptionCommandHandler"/>.
    /// </summary>
    public class DeleteSubscriptionCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteSubscriptionCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public DeleteSubscriptionCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteSubscriptionCommandHandlerTests> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
