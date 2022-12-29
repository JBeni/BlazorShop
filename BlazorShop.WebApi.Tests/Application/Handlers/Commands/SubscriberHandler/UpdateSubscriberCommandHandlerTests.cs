// <copyright file="UpdateSubscriberCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriberCommandHandler"/>.
    /// </summary>
    public class UpdateSubscriberCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriberCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateSubscriberCommandHandlerTests> logger)
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
        public async Task Handle(UpdateSubscriberCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
