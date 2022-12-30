// <copyright file="UpdateRoleCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateRoleCommandHandler"/>.
    /// </summary>
    public class UpdateRoleCommandHandlerTests
    {
        private IRoleService RoleService { get; }
        private ILogger<UpdateRoleCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleCommandHandlerTests"/> class.
        /// </summary>
        public UpdateRoleCommandHandlerTests(IRoleService roleService, ILogger<UpdateRoleCommandHandlerTests> logger)
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
        public Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
