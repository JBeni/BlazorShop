// <copyright file="CreateSubscriberCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="CreateSubscriberCommandHandler"/>.
    /// </summary>
    public class CreateSubscriberCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateSubscriberCommandHandlerTests> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public CreateSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateSubscriberCommandHandlerTests> logger, IUserService userService)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateSubscriberCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
