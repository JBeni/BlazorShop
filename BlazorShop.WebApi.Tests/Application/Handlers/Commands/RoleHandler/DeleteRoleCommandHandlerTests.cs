// <copyright file="DeleteRoleCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteRoleCommandHandler"/>.
    /// </summary>
    public class DeleteRoleCommandHandlerTests
    {
        private IRoleService RoleService { get; }
        private ILogger<DeleteRoleCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleCommandHandlerTests"/> class.
        /// </summary>
        public DeleteRoleCommandHandlerTests(IRoleService roleService, ILogger<DeleteRoleCommandHandlerTests> logger)
        {
            this.RoleService = roleService;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
