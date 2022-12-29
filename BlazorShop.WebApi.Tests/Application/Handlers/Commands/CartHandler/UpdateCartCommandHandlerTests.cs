// <copyright file="UpdateCartCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateCartCommandHandler"/>.
    /// </summary>
    public class UpdateCartCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateCartCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCartCommandHandlerTests"/> class.
        /// </summary>
        public UpdateCartCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateCartCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
