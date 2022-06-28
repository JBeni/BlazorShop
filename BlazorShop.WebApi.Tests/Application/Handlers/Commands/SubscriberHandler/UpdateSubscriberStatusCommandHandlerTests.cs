// <copyright file="UpdateSubscriberStatusCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateSubscriberStatusCommandHandler"/>.
    /// </summary>
    public class UpdateSubscriberStatusCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriberStatusCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberStatusCommandHandlerTests"/> class.
        /// </summary>
        public UpdateSubscriberStatusCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateSubscriberStatusCommandHandlerTests> logger)
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
        public async Task Handle(UpdateSubscriberStatusCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
