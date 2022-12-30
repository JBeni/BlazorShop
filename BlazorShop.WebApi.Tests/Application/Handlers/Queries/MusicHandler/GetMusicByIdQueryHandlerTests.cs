// <copyright file="GetMusicByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.MusicHandler
{
    /// <summary>
    /// Tests for <see cref="GetMusicByIdQueryHandler"/>.
    /// </summary>
    public class GetMusicByIdQueryHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<GetMusicByIdQueryHandlerTests> Logger { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMusicByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetMusicByIdQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetMusicByIdQueryHandlerTests> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public Task Handle(GetMusicByIdQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
