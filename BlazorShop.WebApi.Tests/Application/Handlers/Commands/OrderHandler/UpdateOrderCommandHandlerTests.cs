// <copyright file="UpdateOrderCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateOrderCommandHandler"/>.
    /// </summary>
    public class UpdateOrderCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateOrderCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCommandHandlerTests"/> class.
        /// </summary>
        public UpdateOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateOrderCommandHandlerTests> logger)
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
        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
