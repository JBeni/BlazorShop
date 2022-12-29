// <copyright file="DeleteMusicCommandHandlerTests.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteMusicCommandHandler"/>.
    /// </summary>
    public class DeleteMusicCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteMusicCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMusicCommandHandlerTests"/> class.
        /// </summary>
        public DeleteMusicCommandHandlerTests(IApplicationDbContext dbContext, ILogger<DeleteMusicCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
