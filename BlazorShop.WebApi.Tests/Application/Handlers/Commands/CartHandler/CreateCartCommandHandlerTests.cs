// <copyright file="CreateCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="CreateCartCommandHandler"/>.
    /// </summary>
    public class CreateCartCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateCartCommandHandlerTests> Logger { get; }
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandlerTests"/> class.
        /// </summary>
        public CreateCartCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateCartCommandHandlerTests> logger, UserManager<User> userManager)
        {
            this.DbContext = dbContext;
            this.UserManager = userManager;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
