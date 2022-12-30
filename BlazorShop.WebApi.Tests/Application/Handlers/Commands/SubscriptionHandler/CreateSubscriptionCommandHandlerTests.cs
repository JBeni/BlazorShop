// <copyright file="CreateSubscriptionCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="CreateSubscriptionCommandHandler"/>.
    /// </summary>
    public class CreateSubscriptionCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateSubscriptionCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public CreateSubscriptionCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateSubscriptionCommandHandlerTests> logger)
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
        public Task Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
