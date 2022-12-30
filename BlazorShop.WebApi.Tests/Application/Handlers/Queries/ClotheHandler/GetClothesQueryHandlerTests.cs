// <copyright file="GetClothesQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="GetClothesQueryHandler"/>.
    /// </summary>
    public class GetClothesQueryHandlerTests
    {
        private IApplicationDbContext DbContext { get; }
        private ILogger<GetClothesQueryHandlerTests> Logger { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetClothesQueryHandlerTests"/> class.
        /// </summary>
        public GetClothesQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetClothesQueryHandlerTests> logger, IMapper mapper)
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
        public Task Handle(GetClothesQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
