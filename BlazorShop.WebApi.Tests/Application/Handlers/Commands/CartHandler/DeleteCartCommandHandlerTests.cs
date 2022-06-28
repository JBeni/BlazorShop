// <copyright file="DeleteCartCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteCartCommandHandler"/>.
    /// </summary>
    public class DeleteCartCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteCartCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCartCommandHandlerTests"/> class.
        /// </summary>
        public DeleteCartCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteCartCommandHandlerTests> logger)
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
        public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
