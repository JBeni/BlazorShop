// <copyright file="UpdateClotheCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateClotheCommandHandler"/>.
    /// </summary>
    public class UpdateClotheCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateClotheCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClotheCommandHandlerTests"/> class.
        /// </summary>
        public UpdateClotheCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateClotheCommandHandlerTests> logger)
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
        public Task Handle(UpdateClotheCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
