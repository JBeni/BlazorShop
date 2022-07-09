// <copyright file="AssignUserToRoleCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="AssignUserToRoleCommandHandler"/>.
    /// </summary>
    public class AssignUserToRoleCommandHandlerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<AssignUserToRoleCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignUserToRoleCommandHandlerTests"/> class.
        /// </summary>
        public AssignUserToRoleCommandHandlerTests(IUserService userService, ILogger<AssignUserToRoleCommandHandlerTests> logger)
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
        public async Task Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
