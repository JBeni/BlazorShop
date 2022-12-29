// <copyright file="CreateRoleCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="CreateRoleCommandHandler"/>.
    /// </summary>
    public class CreateRoleCommandHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<CreateRoleCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleCommandHandlerTests"/> class.
        /// </summary>
        public CreateRoleCommandHandlerTests(IRoleService roleService, ILogger<CreateRoleCommandHandlerTests> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
