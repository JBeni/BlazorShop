// <copyright file="CreateClotheCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="CreateClotheCommandHandler"/>.
    /// </summary>
    public class CreateClotheCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateClotheCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClotheCommandHandlerTests"/> class.
        /// </summary>
        public CreateClotheCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateClotheCommandHandlerTests> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(CreateClotheCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
