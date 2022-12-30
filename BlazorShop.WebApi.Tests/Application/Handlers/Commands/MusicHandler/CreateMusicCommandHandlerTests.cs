// <copyright file="CreateMusicCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="CreateMusicCommandHandler"/>.
    /// </summary>
    public class CreateMusicCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<CreateMusicCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMusicCommandHandlerTests"/> class.
        /// </summary>
        public CreateMusicCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateMusicCommandHandlerTests> logger)
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
        public Task Handle(CreateMusicCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
