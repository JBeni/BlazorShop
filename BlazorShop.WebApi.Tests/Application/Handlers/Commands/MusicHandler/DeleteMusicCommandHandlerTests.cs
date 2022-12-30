// <copyright file="DeleteMusicCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteMusicCommandHandler"/>.
    /// </summary>
    public class DeleteMusicCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<DeleteMusicCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMusicCommandHandlerTests"/> class.
        /// </summary>
        public DeleteMusicCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteMusicCommandHandlerTests> logger)
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
        public Task Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
