// <copyright file="CreateUserCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="CreateUserCommandHandler"/>.
    /// </summary>
    public class CreateUserCommandHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<CreateUserCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommandHandlerTests"/> class.
        /// </summary>
        public CreateUserCommandHandlerTests(IUserService userService, ILogger<CreateUserCommandHandlerTests> logger)
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
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
