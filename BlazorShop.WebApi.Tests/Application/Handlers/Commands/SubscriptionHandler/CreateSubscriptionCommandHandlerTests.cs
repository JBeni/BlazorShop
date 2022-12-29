// <copyright file="CreateSubscriptionCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// Tests for <see cref="CreateSubscriptionCommandHandler"/>.
    /// </summary>
    public class CreateSubscriptionCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateSubscriptionCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionCommandHandlerTests"/> class.
        /// </summary>
        public CreateSubscriptionCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateSubscriptionCommandHandlerTests> logger)
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
        public async Task Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
