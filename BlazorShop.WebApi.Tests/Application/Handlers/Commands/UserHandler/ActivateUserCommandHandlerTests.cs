// <copyright file="ActivateUserCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="ActivateUserCommandHandler"/>.
    /// </summary>
    public class ActivateUserCommandHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<ActivateUserCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivateUserCommandHandlerTests"/> class.
        /// </summary>
        public ActivateUserCommandHandlerTests(IUserService userService, ILogger<ActivateUserCommandHandlerTests> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
