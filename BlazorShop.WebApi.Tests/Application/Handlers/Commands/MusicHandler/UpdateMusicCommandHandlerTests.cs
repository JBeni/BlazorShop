// <copyright file="UpdateMusicCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateMusicCommandHandler"/>.
    /// </summary>
    public class UpdateMusicCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateMusicCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMusicCommandHandlerTests"/> class.
        /// </summary>
        public UpdateMusicCommandHandlerTests(IApplicationDbContext dbContext, ILogger<UpdateMusicCommandHandlerTests> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
