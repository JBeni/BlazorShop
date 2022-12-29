// <copyright file="UpdateUserCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateUserCommandHandler"/>.
    /// </summary>
    public class UpdateUserCommandHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCommandHandlerTests"/> class.
        /// </summary>
        public UpdateUserCommandHandlerTests(IUserService userService, ILogger<UpdateUserCommandHandlerTests> logger)
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
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
