// <copyright file="GetReceiptByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.ReceiptHandler
{
    /// <summary>
    /// Tests for <see cref="GetReceiptByIdQueryHandler"/>.
    /// </summary>
    public class GetReceiptByIdQueryHandlerTests
    {
        private IApplicationDbContext DbContext { get; } 
        private ILogger<GetReceiptByIdQueryHandlerTests> Logger { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetReceiptByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetReceiptByIdQueryHandlerTests(IApplicationDbContext dbContext, ILogger<GetReceiptByIdQueryHandlerTests> logger, IMapper mapper)
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
        public Task Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
