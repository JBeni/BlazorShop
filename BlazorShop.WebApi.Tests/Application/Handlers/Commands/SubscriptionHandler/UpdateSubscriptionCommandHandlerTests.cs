// <copyright file="UpdateSubscriptionCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriptionCommandHandler"/>.
    /// </summary>
    public class UpdateSubscriptionCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriptionCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriptionCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateSubscriptionCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
