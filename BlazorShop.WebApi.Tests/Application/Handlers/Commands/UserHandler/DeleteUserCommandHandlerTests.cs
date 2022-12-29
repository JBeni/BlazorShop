// <copyright file="DeleteUserCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteUserCommandHandler"/>.
    /// </summary>
    public class DeleteUserCommandHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<DeleteUserCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandHandlerTests"/> class.
        /// </summary>
        public DeleteUserCommandHandlerTests(IUserService userService, ILogger<DeleteUserCommandHandlerTests> logger)
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
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
