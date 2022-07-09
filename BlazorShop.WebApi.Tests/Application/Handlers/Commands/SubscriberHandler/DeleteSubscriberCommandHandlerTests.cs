// <copyright file="DeleteSubscriberCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteSubscriberCommandHandler"/>.
    /// </summary>
    public class DeleteSubscriberCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteSubscriberCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public DeleteSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteSubscriberCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(DeleteSubscriberCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
