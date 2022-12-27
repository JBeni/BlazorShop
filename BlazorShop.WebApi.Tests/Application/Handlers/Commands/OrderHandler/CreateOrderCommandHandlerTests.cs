// <copyright file="CreateOrderCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// Tests for <see cref="CreateOrderCommandHandler"/>.
    /// </summary>
    public class CreateOrderCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateOrderCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCommandHandlerTests"/> class.
        /// </summary>
        public CreateOrderCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateOrderCommandHandlerTests> logger)
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
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
