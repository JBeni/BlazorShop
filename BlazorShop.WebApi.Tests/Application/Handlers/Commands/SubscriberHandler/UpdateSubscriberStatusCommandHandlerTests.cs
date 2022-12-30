// <copyright file="UpdateSubscriberStatusCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriberStatusCommandHandler"/>.
    /// </summary>
    public class UpdateSubscriberStatusCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateSubscriberStatusCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberStatusCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriberStatusCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateSubscriberStatusCommandHandlerTests> logger)
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
        public Task Handle(UpdateSubscriberStatusCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
