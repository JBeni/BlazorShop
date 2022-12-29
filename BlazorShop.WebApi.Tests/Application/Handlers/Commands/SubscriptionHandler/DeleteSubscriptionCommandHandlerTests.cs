// <copyright file="DeleteSubscriptionCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteSubscriptionCommandHandler"/>.
    /// </summary>
    public class DeleteSubscriptionCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteSubscriptionCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public DeleteSubscriptionCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteSubscriptionCommandHandlerTests> logger)
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
        public async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
