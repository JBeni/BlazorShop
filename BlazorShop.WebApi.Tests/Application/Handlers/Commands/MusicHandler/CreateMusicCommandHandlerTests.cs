// <copyright file="CreateMusicCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="CreateMusicCommandHandler"/>.
    /// </summary>
    public class CreateMusicCommandHandlerTests
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateMusicCommandHandlerTests> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMusicCommandHandlerTests"/> class.
        /// </summary>
        public CreateMusicCommandHandlerTests(IApplicationDbContext dbContext, ILogger<CreateMusicCommandHandlerTests> logger)
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
        public async Task Handle(CreateMusicCommand request, CancellationToken cancellationToken)
        {
        }
    }
}
