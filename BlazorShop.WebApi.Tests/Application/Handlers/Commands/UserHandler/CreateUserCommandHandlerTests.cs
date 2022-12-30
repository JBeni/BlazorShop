// <copyright file="CreateUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="CreateUserCommandHandler"/>.
    /// </summary>
    public class CreateUserCommandHandlerTests
    {
        private IUserService UserService { get; }
        private ILogger<CreateUserCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommandHandlerTests"/> class.
        /// </summary>
        public CreateUserCommandHandlerTests(IUserService userService, ILogger<CreateUserCommandHandlerTests> logger)
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
        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
