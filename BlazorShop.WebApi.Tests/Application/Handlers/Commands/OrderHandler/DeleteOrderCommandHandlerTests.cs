// <copyright file="DeleteOrderCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteOrderCommandHandler"/>.
    /// </summary>
    public class DeleteOrderCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteOrderCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOrderCommandHandlerTests"/> class.
        /// </summary>
        public DeleteOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteOrderCommandHandlerTests> logger)
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
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
