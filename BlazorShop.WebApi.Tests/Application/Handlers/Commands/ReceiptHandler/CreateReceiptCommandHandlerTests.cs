// <copyright file="CreateReceiptCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// Tests for <see cref="CreateReceiptCommandHandler"/>.
    /// </summary>
    public class CreateReceiptCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateReceiptCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReceiptCommandHandlerTests"/> class.
        /// </summary>
        public CreateReceiptCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateReceiptCommandHandlerTests> logger)
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
        public async Task Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
