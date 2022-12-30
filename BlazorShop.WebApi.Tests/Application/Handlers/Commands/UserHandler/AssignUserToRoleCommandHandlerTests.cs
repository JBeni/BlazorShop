// <copyright file="AssignUserToRoleCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="AssignUserToRoleCommandHandler"/>.
    /// </summary>
    public class AssignUserToRoleCommandHandlerTests
    {
        private IUserService UserService { get; }
        private ILogger<AssignUserToRoleCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignUserToRoleCommandHandlerTests"/> class.
        /// </summary>
        public AssignUserToRoleCommandHandlerTests(IUserService userService, ILogger<AssignUserToRoleCommandHandlerTests> logger)
        {
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public Task Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
