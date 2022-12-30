// <copyright file="DeleteUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteUserCommandHandler"/>.
    /// </summary>
    public class DeleteUserCommandHandlerTests
    {
        private IUserService UserService { get; }
        private ILogger<DeleteUserCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandHandlerTests"/> class.
        /// </summary>
        public DeleteUserCommandHandlerTests(IUserService userService, ILogger<DeleteUserCommandHandlerTests> logger)
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
        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
