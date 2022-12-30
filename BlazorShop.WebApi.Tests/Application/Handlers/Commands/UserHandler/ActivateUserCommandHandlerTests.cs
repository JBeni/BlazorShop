// <copyright file="ActivateUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="ActivateUserCommandHandler"/>.
    /// </summary>
    public class ActivateUserCommandHandlerTests
    {
        private IUserService UserService { get; }
        private ILogger<ActivateUserCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivateUserCommandHandlerTests"/> class.
        /// </summary>
        public ActivateUserCommandHandlerTests(IUserService userService, ILogger<ActivateUserCommandHandlerTests> logger)
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
        public Task Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
