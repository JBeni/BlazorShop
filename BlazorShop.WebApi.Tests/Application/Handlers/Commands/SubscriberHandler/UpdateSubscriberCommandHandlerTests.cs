// <copyright file="UpdateSubscriberCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriberCommandHandler"/>.
    /// </summary>
    public class UpdateSubscriberCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateSubscriberCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateSubscriberCommandHandlerTests> logger)
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
        public Task Handle(UpdateSubscriberCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
