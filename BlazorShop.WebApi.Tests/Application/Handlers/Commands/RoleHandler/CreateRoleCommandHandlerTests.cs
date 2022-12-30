// <copyright file="CreateRoleCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.RoleHandler
{
    /// <summary>
    /// Tests for <see cref="CreateRoleCommandHandler"/>.
    /// </summary>
    public class CreateRoleCommandHandlerTests
    {
        private IRoleService RoleService { get; }
        private ILogger<CreateRoleCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleCommandHandlerTests"/> class.
        /// </summary>
        public CreateRoleCommandHandlerTests(IRoleService roleService, ILogger<CreateRoleCommandHandlerTests> logger)
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
        public Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
