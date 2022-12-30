// <copyright file="UpdateUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateUserCommandHandler"/>.
    /// </summary>
    public class UpdateUserCommandHandlerTests
    {
        private IUserService UserService { get; }
        private ILogger<UpdateUserCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCommandHandlerTests"/> class.
        /// </summary>
        public UpdateUserCommandHandlerTests(IUserService userService, ILogger<UpdateUserCommandHandlerTests> logger)
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
        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
