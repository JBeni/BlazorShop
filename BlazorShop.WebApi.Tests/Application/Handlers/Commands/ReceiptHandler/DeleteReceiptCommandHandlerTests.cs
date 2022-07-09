// <copyright file="DeleteReceiptCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteReceiptCommandHandler"/>.
    /// </summary>
    public class DeleteReceiptCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteReceiptCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReceiptCommandHandlerTests"/> class.
        /// </summary>
        public DeleteReceiptCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteReceiptCommandHandlerTests> logger)
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
        public async Task Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
