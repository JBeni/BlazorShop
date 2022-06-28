// <copyright file="CreateCartCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="CreateCartCommandHandler"/>.
    /// </summary>
    public class CreateCartCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateCartCommandHandlerTests> _logger;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandlerTests"/> class.
        /// </summary>
        public CreateCartCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateCartCommandHandlerTests> logger, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
