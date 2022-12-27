// <copyright file="DeleteClotheCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteClotheCommandHandler"/>.
    /// </summary>
    public class DeleteClotheCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteClotheCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteClotheCommandHandlerTests"/> class.
        /// </summary>
        public DeleteClotheCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteClotheCommandHandlerTests> logger)
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
        public async Task Handle(DeleteClotheCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
