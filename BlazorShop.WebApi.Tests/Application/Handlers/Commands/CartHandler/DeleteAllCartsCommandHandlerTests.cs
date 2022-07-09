// <copyright file="DeleteAllCartsCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteAllCartsCommandHandler"/>.
    /// </summary>
    public class DeleteAllCartsCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteAllCartsCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllCartsCommandHandlerTests"/> class.
        /// </summary>
        public DeleteAllCartsCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteAllCartsCommandHandlerTests> logger)
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
        public async Task Handle(DeleteAllCartsCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
