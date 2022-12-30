// <copyright file="UpdateSubscriptionCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriptionCommandHandler"/>.
    /// </summary>
    public class UpdateSubscriptionCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateSubscriptionCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriptionCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateSubscriptionCommandHandlerTests> logger)
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
        public Task Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
