// <copyright file="UpdateCreatedSubscriberCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateCreatedSubscriberCommandHandler"/>.
    /// </summary>
    public class UpdateCreatedSubscriberCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateCreatedSubscriberCommandHandlerTests> Logger { get; }
        private IUserService UserService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCreatedSubscriberCommandHandlerTests"/> class.
        /// </summary>
        public UpdateCreatedSubscriberCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateCreatedSubscriberCommandHandlerTests> logger, IUserService userService)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public Task Handle(UpdateCreatedSubscriberCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
