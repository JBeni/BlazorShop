// <copyright file="UpdateUserEmailCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateUserEmailCommandHandler"/>.
    /// </summary>
    public class UpdateUserEmailCommandHandlerTests
    {
        private IUserService UserService { get; }
        private ILogger<UpdateUserEmailCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserEmailCommandHandlerTests"/> class.
        /// </summary>
        public UpdateUserEmailCommandHandlerTests(IUserService userService, ILogger<UpdateUserEmailCommandHandlerTests> logger)
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
        public Task Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
