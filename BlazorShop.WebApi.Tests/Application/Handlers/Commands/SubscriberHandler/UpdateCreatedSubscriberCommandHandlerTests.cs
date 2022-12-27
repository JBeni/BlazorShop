// <copyright file="UpdateCreatedSubscriberCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateCreatedSubscriberCommandHandler"/>.
    /// </summary>
    public class UpdateCreatedSubscriberCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateCreatedSubscriberCommandHandlerTests> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCreatedSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public UpdateCreatedSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateCreatedSubscriberCommandHandlerTests> logger, IUserService userService)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task Handle(UpdateCreatedSubscriberCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
