// <copyright file="CreateClotheCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="CreateClotheCommandHandler"/>.
    /// </summary>
    public class CreateClotheCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateClotheCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClotheCommandHandlerTests"/> class.
        /// </summary>
        public CreateClotheCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateClotheCommandHandlerTests> logger)
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
        public async Task Handle(CreateClotheCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
