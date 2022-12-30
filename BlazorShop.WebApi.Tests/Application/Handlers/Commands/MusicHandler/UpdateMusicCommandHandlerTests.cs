// <copyright file="UpdateMusicCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateMusicCommandHandler"/>.
    /// </summary>
    public class UpdateMusicCommandHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<UpdateMusicCommandHandlerTests> Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMusicCommandHandlerTests"/> class.
        /// </summary>
        public UpdateMusicCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateMusicCommandHandlerTests> logger)
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
        public Task Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
