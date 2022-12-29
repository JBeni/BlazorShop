// <copyright file="DeleteRoleCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteRoleCommandHandler"/>.
    /// </summary>
    public class DeleteRoleCommandHandlerTests
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<DeleteRoleCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleCommandHandlerTests"/> class.
        /// </summary>
        public DeleteRoleCommandHandlerTests(IRoleService roleService, ILogger<DeleteRoleCommandHandlerTests> logger)
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
        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
